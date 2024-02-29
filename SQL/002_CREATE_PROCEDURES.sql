CREATE OR ALTER PROCEDURE MARKET_PLACE.ITEMS_GET_BY_PAGE_WITH_FILTER
(
	@PAGE_NO INT = 1,
	@PAGE_COUNT INT = 10,
	@ITEM_CATEGORY TINYINT = NULL,
	@MARKET_USER_ID INT,
	@FILTER_BY_OWNER_ID BIT = 0, -- 0 - except owner's items, 1 - only owner's items
	@FILTER_BY_HIGHEST_BIDDER BIT = 0, -- 0 - except bidded items, 1 - only bidded items
	@ORDER_BY_PRICE BIT = NULL,
	@ORDER_BY_DATE BIT = NULL,
	@ONLY_FAV BIT = 0
)
AS BEGIN

	SET @PAGE_NO = @PAGE_NO - 1

	SELECT
		ID,
		TITLE,
		ITEM_DESCRIPTION,
		ITEM_CATEGORY,
		START_PRICE,
		END_PRICE,
		CURRENT_PRICE,
		BID_STEP,
		DATE_START,
		DATE_END,
		HIGHEST_BIDDER,
		OWNER_ID,
		CAST(CASE WHEN F.MARKET_ITEM_ID IS NOT NULL THEN 1 ELSE 0 END AS BIT) AS IS_FAV
	FROM MARKET_PLACE.MARKET_ITEMS AS I
	LEFT JOIN MARKET_PLACE.ITEMS_FAVORITE AS F
		ON F.MARKET_USER_ID = @MARKET_USER_ID
		AND I.ID = F.MARKET_ITEM_ID
	WHERE
		((@FILTER_BY_OWNER_ID = 0 AND OWNER_ID <> @MARKET_USER_ID) OR (@FILTER_BY_OWNER_ID = 1 AND OWNER_ID = @MARKET_USER_ID))
		AND
		((@FILTER_BY_HIGHEST_BIDDER = 0 AND ISNULL(HIGHEST_BIDDER, -1) <> @MARKET_USER_ID) OR (@FILTER_BY_HIGHEST_BIDDER = 1 AND ISNULL(HIGHEST_BIDDER, -1) = @MARKET_USER_ID))
		AND
		(@ONLY_FAV = 0 OR (@ONLY_FAV = 1 AND CAST(CASE WHEN F.MARKET_ITEM_ID IS NOT NULL THEN 1 ELSE 0 END AS BIT) = CAST(1 AS BIT)))
		AND DATE_END_ACTUAL IS NULL
	ORDER BY
		CASE WHEN @ORDER_BY_PRICE = 0 THEN CURRENT_PRICE END ASC,
		CASE WHEN @ORDER_BY_PRICE = 1 THEN CURRENT_PRICE END DESC,
		CASE WHEN @ORDER_BY_DATE = 0 THEN DATE_START END ASC,
		CASE WHEN @ORDER_BY_DATE = 1 THEN DATE_START END DESC
	OFFSET @PAGE_NO * @PAGE_COUNT ROWS FETCH NEXT @PAGE_COUNT ROWS ONLY

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.ITEM_FAVORITE_TOGGLE
(
	@USER_ID INT,
	@ITEM_ID INT
)
AS BEGIN

	DELETE FROM MARKET_PLACE.ITEMS_FAVORITE
	WHERE MARKET_USER_ID = @USER_ID AND MARKET_ITEM_ID = @ITEM_ID

	IF @@ROWCOUNT < 1
	BEGIN
		INSERT INTO MARKET_PLACE.ITEMS_FAVORITE(MARKET_USER_ID, MARKET_ITEM_ID)
		VALUES (@USER_ID, @ITEM_ID)
	END

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.ITEM_ADD_TO_ORDER
(
	@USER_ID INT,
	@ITEM_ID INT,

	@ORDER_ID INT OUTPUT
)
AS BEGIN

	SELECT @ORDER_ID = NEXT VALUE FOR MARKET_PLACE.MARKET_ORDERS_SEQ

	INSERT INTO MARKET_PLACE.MARKET_ORDERS(ID, MARKET_USER_ID, MARKET_ITEM_ID)
	VALUES (@ORDER_ID, @USER_ID, @ITEM_ID)

	UPDATE MARKET_PLACE.MARKET_ITEMS
	SET DATE_END_ACTUAL = GETDATE()
	WHERE ID = @ITEM_ID


END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.ITEM_BID
(
	@USER_ID INT,
	@ITEM_ID INT,

	@BID_RESULT INT = 0 OUTPUT
)
AS BEGIN

	DECLARE @PREVIOUS_BIDDER INT = 0;
	DECLARE @BID_STEP DECIMAL(20, 4) = 0;
	DECLARE @PREVIOUS_PRICE DECIMAL(20, 4) = 0;

	UPDATE I 
	SET @PREVIOUS_PRICE = CURRENT_PRICE,
		CURRENT_PRICE = CURRENT_PRICE + BID_STEP,
		@PREVIOUS_BIDDER = HIGHEST_BIDDER,
		@BID_STEP = BID_STEP,
		HIGHEST_BIDDER = @USER_ID,
		DATE_END_ACTUAL = CASE WHEN CURRENT_PRICE + BID_STEP >= END_PRICE THEN GETDATE() ELSE NULL END
	FROM MARKET_PLACE.MARKET_ITEMS AS I
	WHERE ID = @ITEM_ID
		AND DATE_END_ACTUAL IS NULL
		AND EXISTS ( --CHECK IF BALANCE IS SUFFICIENT
		SELECT 1 FROM MARKET_PLACE.MARKET_USERS AS U
		WHERE U.ID = @USER_ID AND U.BALANCE >= I.CURRENT_PRICE + I.BID_STEP)
	
	--IF BID IS SUCCESSFUL
	IF (@@ROWCOUNT > 0)
	BEGIN
		--BID PAYMENT
		UPDATE MARKET_PLACE.MARKET_USERS
		SET BALANCE = BALANCE - @PREVIOUS_PRICE
		WHERE ID = @USER_ID

		SELECT @BID_RESULT = 1 --PAYED

		--RETURNING BIDDED MONEY TO PREVIOUS BIDDER
		UPDATE MARKET_PLACE.MARKET_USERS
		SET BALANCE = BALANCE + @BID_STEP
		WHERE ID = @PREVIOUS_BIDDER
			AND @PREVIOUS_BIDDER <> 0
			AND @BID_STEP <> 0

		--IF OUR BID IS A WINNER AND WE BOUGHT THIS ITEM
		IF EXISTS (SELECT 1 FROM MARKET_PLACE.MARKET_ITEMS WHERE ID = @ITEM_ID AND DATE_END_ACTUAL IS NOT NULL)
		BEGIN
			SELECT @BID_RESULT = 2 --BAUGHT
		END
	END

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.ITEM_ADD_TO_MARKET
(
	@TITLE NVARCHAR(20),
	@ITEM_DESCRIPTION NVARCHAR(200),
	@ITEM_CATEGORY TINYINT,
	@PRICE_START DECIMAL(20, 4),
	@PRICE_END DECIMAL(20, 4) = NULL,
	@BID_STEP DECIMAL(20, 4) = NULL,
	@DATE_END DATETIME = NULL,
	@OWNER_ID INT,

	@ITEM_ID INT OUTPUT
)
AS BEGIN

	SELECT @ITEM_ID = NEXT VALUE FOR MARKET_PLACE.MARKET_ITEMS_SEQ

	INSERT INTO MARKET_PLACE.MARKET_ITEMS (
		ID,
		TITLE,
		ITEM_DESCRIPTION,
		ITEM_CATEGORY,
		START_PRICE,
		END_PRICE,
		CURRENT_PRICE,
		BID_STEP,
		DATE_START,
		DATE_END,
		OWNER_ID)
     VALUES (
		@ITEM_ID,
		@TITLE,
		@ITEM_DESCRIPTION,
		@ITEM_CATEGORY,
		@PRICE_START,
		ISNULL(@PRICE_END, @PRICE_START),
		@PRICE_START,
		@BID_STEP,
		GETDATE(),
		@DATE_END,
		@OWNER_ID)

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.ITEM_IMAGE_ADD
(
	@ITEM_ID INT,
	@IMAGE_BINARY VARBINARY(MAX)
)
AS BEGIN

	INSERT INTO MARKET_PLACE.ITEM_IMAGES (ITEM_ID, IMAGE_BINARY)
	VALUES (@ITEM_ID, @IMAGE_BINARY)

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.ITEM_IMAGE_GET
(
	@ITEM_ID INT
)
AS BEGIN

	WAITFOR DELAY '00:00:01';
	SELECT IMAGE_BINARY FROM MARKET_PLACE.ITEM_IMAGES WHERE ITEM_ID = @ITEM_ID

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.HISTORY_SAVE
(
	@MARKET_USER_ID INT,
	@MARKET_PARTNER_ID INT,
	@MARKET_ITEM_ID INT,
	@OPERATION_TYPE TINYINT,
	@COST DECIMAL(20, 4)
)
AS BEGIN

	INSERT INTO MARKET_PLACE.HISTORY(MARKET_USER_ID, MARKET_PARTNER_ID, MARKET_ITEM_ID, OPERATION_TYPE, COST)
	VALUES (@MARKET_USER_ID, @MARKET_PARTNER_ID, @MARKET_ITEM_ID, @OPERATION_TYPE, @COST)

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.HISTORY_GET
(
	@MARKET_USER_ID INT
)
AS BEGIN

	SELECT
		P.PERSON_NAME,
		P.EMAIL,
		I.TITLE,
		H.OPERATION_TYPE,
		H.COST,
		H.HISTORY_DATE,
		O.ORDER_STATE
	FROM MARKET_PLACE.HISTORY AS H
	JOIN MARKET_PLACE.MARKET_ITEMS AS I
		ON H.MARKET_ITEM_ID = I.ID
	JOIN MARKET_PLACE.MARKET_PERSONS AS P
		ON H.MARKET_PARTNER_ID = P.MARKET_USER_ID
	LEFT JOIN MARKET_PLACE.MARKET_ORDERS AS O
		ON O.MARKET_ITEM_ID = H.MARKET_ITEM_ID
	WHERE H.MARKET_USER_ID = @MARKET_USER_ID

END;
GO