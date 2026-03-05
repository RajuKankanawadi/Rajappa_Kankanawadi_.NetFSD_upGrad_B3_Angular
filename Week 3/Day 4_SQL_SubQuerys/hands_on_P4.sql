
-- P4 – Order Cleanup and Data Maintenance

 create database EventDB3

 use EventDB3
-- 1. Create Customers Table
CREATE TABLE customers (
customer_id INT PRIMARY KEY,
customer_name VARCHAR(100)
);

-- Insert sample customers
INSERT INTO customers VALUES
(1, 'Ravi'),
(2, 'Anita'),
(3, 'Karan');

-- 2. Orders Table
CREATE TABLE orders (
order_id INT PRIMARY KEY,
customer_id INT,
order_status INT,  -- 1 = Pending, 2 = Completed, 3 = Rejected
order_date DATE,
required_date DATE,
shipped_date DATE,
FOREIGN KEY (customer_id) REFERENCES customers(customer_id)
);

-- Insert sample orders
INSERT INTO orders VALUES
(101, 1, 2, '2023-01-10', '2023-01-15', '2023-01-14'),
(102, 1, 3, '2022-02-05', '2022-02-10', '2022-02-11'),
(103, 2, 2, '2024-03-01', '2024-03-05', '2024-03-04'),
(104, 2, 2, '2024-04-01', '2024-04-05', '2024-04-06'),
(105, 3, 1, '2024-05-01', '2024-05-05', NULL);

-- 3. Archive Table
CREATE TABLE archived_orders (
order_id INT,
customer_id INT,
order_status INT,
order_date DATE,
required_date DATE,
shipped_date DATE
);

-- 4. Insert Rejected Orders Older Than 1 Year Into Archive Table
INSERT INTO archived_orders
SELECT *
FROM orders
WHERE order_status = 3
AND order_date < DATEADD(YEAR, -1, GETDATE());

-- 5. Delete Those Orders From Main Orders Table
DELETE FROM orders
WHERE order_id IN (
SELECT order_id
FROM archived_orders
);

-- 6. Customers Whose All Orders Are Completed (Nested Query)
SELECT customer_id
FROM orders
GROUP BY customer_id
HAVING COUNT(*) =
(
SELECT COUNT(*)
FROM orders o2
WHERE o2.customer_id = orders.customer_id
AND o2.order_status = 2
);

-- 7. Display Order Processing Delay
SELECT
order_id,
customer_id,
order_date,
shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay_days
FROM orders;

-- 8. Mark Orders as Delayed or On Time
SELECT
order_id,
order_date,
required_date,
shipped_date,
CASE
WHEN shipped_date > required_date THEN 'Delayed'
ELSE 'On Time'
END AS delivery_status
FROM orders;

-- 9. Final Report (Delay + Status Together)
SELECT
order_id,
customer_id,
order_date,
required_date,
shipped_date,
DATEDIFF(DAY, order_date, shipped_date) AS processing_delay,
CASE
WHEN shipped_date > required_date THEN 'Delayed'
ELSE 'On Time'
END AS delivery_status
FROM orders;
