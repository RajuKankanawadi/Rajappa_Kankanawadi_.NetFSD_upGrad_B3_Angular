CREATE DATABASE ProductDB
USE ProductDB

CREATE TABLE Products
(
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NULL
);
ALTER TABLE Products
ADD Stock INT NULL;

INSERT INTO Products (ProductName, Category, Price, Stock)
VALUES 
('Laptop', 'Electronics', 60000, 10),
('Mobile', 'Electronics', 25000, 20),
('Pen', 'Stationery', NULL, 100);

SELECT * FROM Products;

-- INSERT DATA ---

CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2),
    @Stock INT
AS
BEGIN
    INSERT INTO Products(ProductName, Category, Price, Stock)
    VALUES (@ProductName, @Category, @Price, @Stock)
END

-- GET ALL PRODUCTS ---

CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products
END

-- UPDATE THE PRODUCTS ---
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2),
    @Stock INT
AS
BEGIN
    UPDATE Products
    SET ProductName=@ProductName,
        Category=@Category,
        Price=@Price,
        Stock=@Stock
    WHERE ProductId=@ProductId
END

--- DELETE PRODUCTS ---
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId=@ProductId
END


---- EXEC - INSERT PRODUCTS ---
EXEC sp_InsertProduct 
    @ProductName = 'Keyboard',
    @Category = 'Electronics',
    @Price = 1500,
    @Stock = 5;

--- EXEC -- ALL PRODUCTS ---
EXEC sp_GetAllProducts;

-- EXEC --- UPDATE PRODUCTS ---
EXEC sp_UpdateProduct 
    @ProductId = 1,
    @ProductName = 'Gaming Keyboard',
    @Category = 'Electronics',
    @Price = 2500,
    @Stock = 10;

--- EXEC --- DELETE PRODUCTS ---
EXEC sp_DeleteProduct 
    @ProductId = 1;