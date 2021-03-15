--DROP DATABASE StoneTest
--GO
CREATE DATABASE StoneTest
GO

USE StoneTest
GO

CREATE TABLE Currency(
    ID NVARCHAR(10) PRIMARY KEY,
    name NCHAR(100),
    eng_name NCHAR(100),
    nominal INT,
    parent_code NCHAR(100),
    num_code NCHAR(10),
    char_code NCHAR(10)
)

CREATE TABLE CurrencyRate(
    ID NVARCHAR(10),
    date DATE,
    num_code NCHAR(10),
    char_code NCHAR(10),
    nominal INT,
    name NCHAR(100),
    value DECIMAL(20,4),
    CONSTRAINT PK_Date_CharCode PRIMARY KEY(date, char_code)
)
GO

CREATE OR ALTER FUNCTION Get_CurrencyRate(@CharCode NCHAR(100), @Date DATE)
RETURNS DECIMAL(20,4) AS
BEGIN
    DECLARE @result DECIMAL(20,4);

    SELECT @result = value
    FROM CurrencyRate
    WHERE char_code = @CharCode AND date = @Date

    RETURN @result;
END