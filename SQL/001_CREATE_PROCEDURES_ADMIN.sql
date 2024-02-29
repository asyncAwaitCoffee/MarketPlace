CREATE OR ALTER PROCEDURE MARKET_PLACE.USER_REGISTRATION
(
	@USER_LOGIN VARCHAR(50),
	@USER_PASSWORD NVARCHAR(50)
)
AS BEGIN

	DECLARE @MARKET_USER_ID INT = NEXT VALUE FOR MARKET_PLACE.MARKET_USERS_SEQ

	INSERT INTO MARKET_PLACE.MARKET_USERS(ID, USER_LOGIN, USER_PASSWORD, REG_DATE)
	VALUES (@MARKET_USER_ID, @USER_LOGIN, @USER_PASSWORD, GETDATE())

	INSERT INTO MARKET_PLACE.MARKET_PERSONS(MARKET_USER_ID)
	VALUES (@MARKET_USER_ID)

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.USER_AUTHORIZATION
(
	@USER_LOGIN VARCHAR(50),
	@USER_PASSWORD NVARCHAR(50),

	@USER_ID INT OUTPUT,
	@USER_LEVEL INT OUTPUT
)
AS BEGIN

	SELECT
		@USER_ID = ID,
		@USER_LEVEL = USER_LEVEL
	FROM MARKET_PLACE.MARKET_USERS AS U
	WHERE USER_LOGIN = @USER_LOGIN
		AND USER_PASSWORD = @USER_PASSWORD

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.USER_PERSON_DATA_UPDATE
(
	@USER_ID INT,
	@PERSON_NAME NVARCHAR(100),
	@EMAIL NVARCHAR(50),
	@COUNTRY_ID TINYINT = 0,
	@CITY_ID TINYINT = 0
)
AS BEGIN

	UPDATE MARKET_PLACE.MARKET_PERSONS
	SET PERSON_NAME = @PERSON_NAME,
		EMAIL = @EMAIL,
		COUNTRY_ID = @COUNTRY_ID,
		CITY_ID = @CITY_ID
	WHERE MARKET_USER_ID = @USER_ID

END;
GO

CREATE OR ALTER PROCEDURE MARKET_PLACE.USER_PERSON_DATA_GET
(
	@USER_ID INT
)
AS BEGIN

	SELECT
		PERSON_NAME,
		EMAIL,
		BALANCE
	FROM MARKET_PLACE.MARKET_PERSONS
	WHERE MARKET_USER_ID = @USER_ID	

END;
GO