
-- PROBLEM 1 == Transactions and Trigger Implementation

USE ECommerceDB1

--  CREATE TABLES


-- Stores Table
CREATE TABLE stores(
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100)
);

-- Products Table
CREATE TABLE products(
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100),
    list_price DECIMAL(10,2)
);

-- Orders Table
CREATE TABLE orders(
    order_id INT PRIMARY KEY,
    order_date DATE,
    store_id INT,
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

-- Order Items Table
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

-- Stocks Table
CREATE TABLE stocks(
    product_id INT PRIMARY KEY,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

-- Insert data into the tables

INSERT INTO stores VALUES
(1,'Mumbai Store'),
(2,'Delhi Store'),
(3,'Bangalore Store');

SELECT * FROM stores;

INSERT INTO products VALUES
(1,'Car Battery',5000),
(2,'Brake Pads',2000),
(3,'Oil Filter',500),
(4,'Engine Oil',1200),
(5,'Headlight',1500);

SELECT * FROM products;

INSERT INTO stocks VALUES
(1,50),
(2,100),
(3,40),
(4,80),
(5,60);

SELECT * FROM stocks;


--  CREATE TRIGGER ==  Automatically reduce stock after order item insert

CREATE TRIGGER trg_UpdateStockAfterOrder
ON order_items
AFTER INSERT
AS
BEGIN

    -- Check stock availability
    IF EXISTS
    (
        SELECT 1
        FROM inserted i
        JOIN stocks s
        ON i.product_id = s.product_id
        WHERE s.quantity < i.quantity
    )
    BEGIN
        RAISERROR ('Stock is insufficient for this order.',16,1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    -- Reduce stock
    UPDATE s
    SET s.quantity = s.quantity - i.quantity
    FROM stocks s
    JOIN inserted i
    ON s.product_id = i.product_id;

END;


--  TRANSACTION : PLACE ORDER --

BEGIN TRY

BEGIN TRANSACTION

-- Insert Order
INSERT INTO orders
VALUES (1,'2024-07-01',1);

-- Insert Order Items
INSERT INTO order_items VALUES
(1,1,1,5,5000,0.05),
(2,1,2,3,2000,0.02);

COMMIT TRANSACTION;

PRINT 'Order placed successfully';

END TRY

BEGIN CATCH

ROLLBACK TRANSACTION

PRINT 'Order failed due to insufficient stock';

END CATCH;

--- CHECK UPDATED STOCK

SELECT * FROM stocks;

--- VIEW ORDER DETAILS

SELECT * FROM orders;

SELECT * FROM order_items;

---------------------------------------------
-- PROBLEM -- 2 --

ALTER TABLE orders
ADD order_status INT;

-- Atomic Order Cancellation with SAVEPOINT

DECLARE @CancelOrderID INT = 1;

BEGIN TRY

BEGIN TRANSACTION

-- SAVEPOINT before stock restoration 
SAVE TRANSACTION BeforeStockRestore;

-- Restore stock quantities 

UPDATE s
SET s.quantity = s.quantity + oi.quantity
FROM stocks s
JOIN order_items oi
ON s.product_id = oi.product_id
WHERE oi.order_id = @CancelOrderID;


-- Check if order exists 
IF NOT EXISTS
(
    SELECT 1
    FROM orders
    WHERE order_id = @CancelOrderID
)
BEGIN
    RAISERROR ('Order does not exist.',16,1);
END


-- Update order status to Rejected 

UPDATE orders
SET  order_status  = 3
WHERE order_id = @CancelOrderID;


-- Commit transaction 

COMMIT TRANSACTION;

PRINT 'Order cancelled successfully and stock restored.';

END TRY


BEGIN CATCH

-- Rollback only to savepoint 

ROLLBACK TRANSACTION BeforeStockRestore;

PRINT 'Error occurred during order cancellation.';
PRINT ERROR_MESSAGE();

END CATCH;

-- Check Results

SELECT * FROM stocks;

SELECT * FROM orders;

SELECT * FROM order_items;