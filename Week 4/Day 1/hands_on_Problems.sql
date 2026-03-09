
-- PROBLEM -- 1--

CREATE DATABASE ECommerceDB;

USE ECommerceDB;

--  Create Tables

CREATE TABLE stores(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

CREATE TABLE products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);

CREATE TABLE orders(
    order_id INT PRIMARY KEY,
    order_date DATE,
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

CREATE TABLE order_items(
    item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(4,2),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

--  Insert Sample Data

INSERT INTO stores VALUES
(1,'Mumbai Store'),
(2,'Delhi Store'),
(3,'Bangalore Store');

INSERT INTO products VALUES
(1,'Laptop',50000),
(2,'Mobile',20000),
(3,'Tablet',15000),
(4,'Headphones',3000),
(5,'Smart Watch',8000);

INSERT INTO orders VALUES
(1,'2024-01-10',1),
(2,'2024-02-15',2),
(3,'2024-03-12',3),
(4,'2024-04-05',1),
(5,'2024-05-18',2);

INSERT INTO order_items VALUES
(1,1,1,2,50000,0.10),
(2,1,4,5,3000,0.05),
(3,2,2,3,20000,0.05),
(4,3,3,4,15000,0.08),
(5,4,5,2,8000,0.02),
(6,5,2,6,20000,0.05),
(7,3,1,1,50000,0.10);

--  Stored Procedure: Total Sales Per Store

CREATE PROCEDURE sp_TotalSalesPerStore
AS
BEGIN
    SELECT 
        s.store_id,
        s.store_name,
        SUM(oi.quantity * oi.list_price * (1 - ISNULL(oi.discount,0))) AS total_sales
    FROM stores s
    JOIN orders o 
        ON s.store_id = o.store_id
    JOIN order_items oi 
        ON o.order_id = oi.order_id
    GROUP BY s.store_id, s.store_name
    ORDER BY total_sales DESC;
END;

-- Execute 
 EXEC sp_TotalSalesPerStore;

-- Stored Procedure: Orders By Date Range

CREATE PROCEDURE sp_GetOrdersByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        order_id,
        order_date,
        store_id
    FROM orders
    WHERE order_date BETWEEN @StartDate AND @EndDate
    ORDER BY order_date;
END;

   -- Execute
 EXEC sp_GetOrdersByDateRange @StartDate = '2024-01-01', @EndDate = '2024-12-31';

-- Scalar Function: Calculate Total Price After Discount

CREATE FUNCTION fn_CalculateDiscountPrice

(
    @price DECIMAL(10,2),
    @discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @finalPrice DECIMAL(10,2)

    SET @finalPrice = @price * (1 - ISNULL(@discount,0))

    RETURN @finalPrice
END;

-- Execute --
SELECT 
    product_id,
    list_price,
    discount,
    dbo.fn_CalculateDiscountPrice(list_price, discount) AS final_price
FROM order_items;

-- Execute --
SELECT dbo.fn_CalculateDiscountPrice(1000,0.10);


-- Table-Valued Function: Top 5 Selling Products

CREATE FUNCTION fn_Top5SellingProducts()
RETURNS TABLE
AS
RETURN
(
    SELECT TOP 5
        p.product_id,
        p.product_name,
        SUM(oi.quantity) AS total_quantity_sold
    FROM order_items oi
    JOIN products p
        ON oi.product_id = p.product_id
    GROUP BY p.product_id, p.product_name
    ORDER BY total_quantity_sold DESC
);

 SELECT * FROM fn_Top5SellingProducts();

 --------------------------------------------------------------------

 -- PROBLEM -- 2

 -- Stocks Table
 CREATE TABLE stocks
(
    product_id INT PRIMARY KEY,
    quantity INT
);

-- Insert data into  Table
INSERT INTO stocks VALUES
(1,50),
(2,100),
(3,40),
(4,80),
(5,60);

SELECT * FROM stocks

INSERT INTO order_items
VALUES (9,3,1,5,3000,0.10)

SELECT * FROM order_items


CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN

BEGIN TRY

    -- Check if stock is sufficient
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN stocks s ON i.product_id = s.product_id
        WHERE s.quantity < i.quantity
    )

    BEGIN
        RAISERROR('Stock is insufficient for this order.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Update stock quantity
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i
    ON s.product_id = i.product_id;

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION;

    DECLARE @ErrorMessage NVARCHAR(4000);
    SET @ErrorMessage = ERROR_MESSAGE();

    RAISERROR(@ErrorMessage,16,1);

END CATCH

END;

------------------------------------------------------------

-- PROBLEM -- 3 

-- Shipped_date Column
ALTER TABLE orders
ADD shipped_date DATE;

-- Oder_status Column
ALTER TABLE orders
ADD order_status INT;

-- Creates a trigger : name - trg_ValidateOrderStatus.

CREATE TRIGGER trg_ValidateOrderStatus
ON orders
AFTER UPDATE
AS
BEGIN

BEGIN TRY

    -- Validation Condition
    IF EXISTS
    (
        SELECT 1
        FROM inserted
        WHERE order_status = 3
        AND shipped_date IS NULL
    )

    BEGIN

        RAISERROR('Cannot set order status to Completed without shipped date.',16,1);

        ROLLBACK TRANSACTION;

        RETURN;

    END

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION;

    DECLARE @ErrorMessage NVARCHAR(4000);

    SET @ErrorMessage = ERROR_MESSAGE();

    RAISERROR(@ErrorMessage,16,1);

END CATCH

END;

--- Test Trigger

UPDATE orders
SET order_status = 4
WHERE order_id = 3;


UPDATE orders
SET shipped_date = '2024-02-11',
    order_status = 4
WHERE order_id = 4;


SELECT * FROM orders;


-----------------------------------------------------------

-- Problem -- 4

USE ECommerceDB;


   --- Ensure required column exists
IF NOT EXISTS (
    SELECT * 
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'orders'
    AND COLUMN_NAME = 'order_status'
)
BEGIN
    ALTER TABLE orders
    ADD order_status INT;
END


   -- Update some orders as Completed

UPDATE orders
SET order_status = 4
WHERE order_id IN (SELECT TOP 3 order_id FROM orders);

-- STEP 3: Cursor-Based Revenue Calculation

BEGIN TRY

    BEGIN TRANSACTION

    -- Temporary table to store order revenue 
    CREATE TABLE #OrderRevenue
    (
        store_id INT,
        order_id INT,
        revenue DECIMAL(12,2)
    );

    DECLARE @order_id INT
    DECLARE @store_id INT
    DECLARE @revenue DECIMAL(12,2)

   -- Cursor to iterate completed orders 
    DECLARE OrderCursor CURSOR FOR
    SELECT order_id, store_id
    FROM orders
    WHERE order_status = 4;

    OPEN OrderCursor

    FETCH NEXT FROM OrderCursor INTO @order_id, @store_id

    WHILE @@FETCH_STATUS = 0
    BEGIN

        -- Calculate revenue for each order 
        SELECT 
        @revenue = SUM(quantity * list_price * (1 - ISNULL(discount,0)))
        FROM order_items
        WHERE order_id = @order_id;

        -- Insert into temporary table 
        INSERT INTO #OrderRevenue
        VALUES (@store_id, @order_id, @revenue);

        FETCH NEXT FROM OrderCursor INTO @order_id, @store_id

    END

    CLOSE OrderCursor
    DEALLOCATE OrderCursor


    -- Display store-wise revenue 
    SELECT 
        s.store_name,
        SUM(r.revenue) AS total_store_revenue
    FROM #OrderRevenue r
    JOIN stores s
        ON r.store_id = s.store_id
    GROUP BY s.store_name;


    COMMIT TRANSACTION

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION

    PRINT 'Error occurred during revenue calculation'
    PRINT ERROR_MESSAGE()
    PRINT ERROR_LINE()

END CATCH

 