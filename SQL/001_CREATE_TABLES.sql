/*
	CREATE SCHEMA MARKET_PLACE
*/


DROP TABLE IF EXISTS MARKET_PLACE.MARKET_USERS
DROP SEQUENCE IF EXISTS MARKET_PLACE.MARKET_USERS_SEQ


CREATE SEQUENCE MARKET_PLACE.MARKET_USERS_SEQ
AS INT
START WITH 1
INCREMENT BY 1
CACHE 100

CREATE TABLE MARKET_PLACE.MARKET_USERS
(
	ID INT NOT NULL,
	USER_LOGIN NVARCHAR(20) NOT NULL,
	USER_PASSWORD NVARCHAR(32) NOT NULL,
	REG_DATE DATETIME NOT NULL,
	USER_LEVEL INT NOT NULL DEFAULT 1,
	BALANCE DECIMAL(20, 4) NOT NULL DEFAULT 0
)

CREATE UNIQUE CLUSTERED INDEX MARKET_USERS_CI ON MARKET_PLACE.MARKET_USERS
(
	USER_LOGIN ASC
)


DROP TABLE IF EXISTS MARKET_PLACE.MARKET_PERSONS


CREATE TABLE MARKET_PLACE.MARKET_PERSONS
(
	MARKET_USER_ID INT NOT NULL,
	PERSON_NAME NVARCHAR(100) NULL,
	EMAIL NVARCHAR(50) NULL,
	COUNTRY_ID TINYINT NULL,
	CITY_ID TINYINT NULL,
	IS_VERIFIED BIT NOT NULL DEFAULT 0
)

CREATE UNIQUE CLUSTERED INDEX MARKET_PERSONS_CI ON MARKET_PLACE.MARKET_PERSONS
(
	MARKET_USER_ID ASC
)


DROP TABLE IF EXISTS MARKET_PLACE.MARKET_ITEMS
DROP SEQUENCE IF EXISTS MARKET_PLACE.MARKET_ITEMS_SEQ


CREATE SEQUENCE MARKET_PLACE.MARKET_ITEMS_SEQ
AS INT
START WITH 1
INCREMENT BY 1
CACHE 100

CREATE TABLE MARKET_PLACE.MARKET_ITEMS
(
	ID INT NOT NULL DEFAULT NEXT VALUE FOR MARKET_PLACE.MARKET_ITEMS_SEQ,
	TITLE NVARCHAR(20) NOT NULL,
	ITEM_DESCRIPTION NVARCHAR(200) NOT NULL,
	ITEM_CATEGORY TINYINT NOT NULL,
	START_PRICE DECIMAL(20, 4) NOT NULL,
	END_PRICE DECIMAL(20, 4) NOT NULL,
	CURRENT_PRICE DECIMAL(20, 4) NOT NULL,
	BID_STEP DECIMAL(20, 4) NULL,
	DATE_START DATETIME NOT NULL,
	DATE_END DATETIME NULL,
	DATE_END_ACTUAL DATETIME NULL,
	HIGHEST_BIDDER INT NULL,
	OWNER_ID INT NOT NULL
)

CREATE UNIQUE CLUSTERED INDEX MARKET_ITEMS_ID_CI ON MARKET_PLACE.MARKET_ITEMS
(
	ID ASC
)

CREATE NONCLUSTERED INDEX MARKET_ITEMS_OWNER_ID_NCI ON MARKET_PLACE.MARKET_ITEMS
(
	OWNER_ID ASC,
	DATE_END_ACTUAL ASC
)

CREATE NONCLUSTERED INDEX MARKET_ITEMS_HIGHEST_BIDDER_NCI ON MARKET_PLACE.MARKET_ITEMS
(
	HIGHEST_BIDDER ASC
)

CREATE NONCLUSTERED INDEX MARKET_ITEMS_ITEM_CATEGORY_NCI ON MARKET_PLACE.MARKET_ITEMS
(
	ITEM_CATEGORY ASC
)


DROP TABLE IF EXISTS MARKET_PLACE.ITEM_IMAGES


CREATE TABLE MARKET_PLACE.ITEM_IMAGES
(
	ITEM_ID INT NOT NULL,
	IMAGE_BINARY VARBINARY(MAX)
)

CREATE UNIQUE CLUSTERED INDEX ITEM_IMAGES_ITEM_ID_CI ON MARKET_PLACE.ITEM_IMAGES
(
	ITEM_ID ASC
)


DROP TABLE IF EXISTS MARKET_PLACE.MARKET_ORDERS
DROP SEQUENCE IF EXISTS MARKET_PLACE.MARKET_ORDERS_SEQ


CREATE SEQUENCE MARKET_PLACE.MARKET_ORDERS_SEQ
AS INT
START WITH 1
INCREMENT BY 1
CACHE 100

CREATE TABLE MARKET_PLACE.MARKET_ORDERS
(
	ID INT NOT NULL,
	MARKET_USER_ID INT,
	MARKET_ITEM_ID INT,
	ORDER_DATE DATETIME DEFAULT GETDATE(),
	ORDER_STATE TINYINT DEFAULT 0
)

CREATE CLUSTERED INDEX MARKET_ORDERS_MARKET_USER_ID_CI ON MARKET_PLACE.MARKET_ORDERS
(
	MARKET_USER_ID ASC
)


DROP TABLE IF EXISTS MARKET_PLACE.HISTORY


CREATE TABLE MARKET_PLACE.HISTORY
(
	MARKET_USER_ID INT,
	MARKET_PARTNER_ID INT,
	MARKET_ITEM_ID INT,
	OPERATION_TYPE TINYINT,
	COST DECIMAL(20, 4),
	HISTORY_DATE DATETIME DEFAULT GETDATE()
)

CREATE CLUSTERED INDEX HISTORY_MARKET_USER_ID_CI ON MARKET_PLACE.HISTORY
(
	MARKET_USER_ID
)