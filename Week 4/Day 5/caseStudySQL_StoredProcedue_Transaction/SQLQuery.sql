CREATE  DATABASE BookMartOnline;

USE BookMartOnline;

-- Books Table

CREATE TABLE Books (
    BookID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(150) NOT NULL,
    Stock INT NOT NULL CHECK (Stock >= 0),
    Price DECIMAL(10,2) NOT NULL
);

    -- Orders Table

CREATE TABLE Orders (
    OrderID INT IDENTITY(1,1) PRIMARY KEY,
    BookID INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),
    OrderDate DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);

-- Create Stored Procedure

CREATE PROCEDURE sp_AddNewBook

    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN

BEGIN TRY

    INSERT INTO Books (Title, Stock, Price)
    VALUES (@Title, @Stock, @Price);

    PRINT 'Book added successfully.';

END TRY

BEGIN CATCH

    PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE();

END CATCH

END

-- Stored Procedure With Transaction --

CREATE PROCEDURE sp_PlaceOrder
    @BookID INT,
    @Quantity INT
AS
BEGIN

SET XACT_ABORT ON

BEGIN TRY

    BEGIN TRANSACTION;

    -- Check book exists and stock
    IF NOT EXISTS (
        SELECT 1
        FROM Books
        WHERE BookID = @BookID
        AND Stock >= @Quantity
    )
    BEGIN
        RAISERROR('Not enough stock or book not found.',16,1);
    END

    -- Reduce stock
    UPDATE Books
    SET Stock = Stock - @Quantity
    WHERE BookID = @BookID;

    -- Insert order
    INSERT INTO Orders(BookID, Quantity)
    VALUES(@BookID, @Quantity);

    COMMIT TRANSACTION;

    PRINT 'Order placed successfully.';

END TRY

BEGIN CATCH

    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT 'Error ' + CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE();

END CATCH

END

-- Add data to Books Table -- 
EXEC sp_AddNewBook 'SQL Server Fundamentals', 10, 450;
EXEC sp_AddNewBook 'C# Programming Guide', 5, 550;
EXEC sp_AddNewBook 'ASP.NET Core', 3, 700;
EXEC sp_AddNewBook 'JavaScript Basics', 8, 400;
EXEC sp_AddNewBook 'Database Design Concepts', 2, 650;

--Successful Order --
EXEC sp_PlaceOrder 1, 2;

-- Check results --
SELECT * FROM Books;
SELECT * FROM Orders;

-- Insufficient Stock --
EXEC sp_PlaceOrder 3, 10;

-- Invalid BookID --
EXEC sp_PlaceOrder 100, 1;

-- Final Data Check --
SELECT * FROM Books;
SELECT * FROM Orders;

