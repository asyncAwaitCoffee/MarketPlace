/*
	CREATE SCHEMA MARKET_PLACE
*/

/*
DROP TABLE IF EXISTS MARKET_PLACE.MARKET_USERS
DROP SEQUENCE IF EXISTS MARKET_PLACE.MARKET_USERS_SEQ
*/

CREATE SEQUENCE MARKET_PLACE.MARKET_USERS_SEQ
AS INT
START WITH 1
INCREMENT BY 1
CACHE 100

CREATE TABLE MARKET_PLACE.MARKET_USERS
(
	ID INT NOT NULL DEFAULT NEXT VALUE FOR MARKET_PLACE.MARKET_USERS_SEQ,
	USER_LOGIN NVARCHAR(20) NOT NULL,
	USER_PASSWORD NVARCHAR(32) NOT NULL,
	REG_DATE DATETIME NOT NULL
)

CREATE UNIQUE CLUSTERED INDEX MARKET_USERS_CI ON MARKET_PLACE.MARKET_USERS
(
	USER_LOGIN ASC
)