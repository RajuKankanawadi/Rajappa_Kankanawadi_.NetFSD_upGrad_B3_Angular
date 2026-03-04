USE EventDB

-- 1. Problem -------

--- Customers Table---
CREATE TABLE customers
(
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE
) 

--- Insert Data Into The Customers Table---
INSERT INTO customers (customer_id, first_name, last_name, email) VALUES
(1, 'Ravi', 'Sharma', 'ravi@gmail.com'),
(2, 'Priya', 'Patel', 'priya@gmail.com'),
(3, 'Amit', 'Verma', 'amit@gmail.com'),
(4, 'Sneha', 'Reddy', 'sneha@gmail.com')

SELECT * FROM customers

--- Orders Table ---
CREATE TABLE orders
(
    order_id INT PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATE NOT NULL,
    order_status INT NOT NULL,
  
    FOREIGN KEY (customer_id) 
    REFERENCES customers(customer_id)
)

--- Insert Data into the Orders Table
INSERT INTO orders (order_id, customer_id, order_date, order_status) VALUES
(101, 1, '2026-03-01', 1), 
(102, 2, '2026-03-02', 4),  -- Completed
(103, 1, '2026-03-03', 2), 
(104, 3, '2026-03-04', 1),  -- Pending
(105, 4, '2026-03-05', 4), 
(106, 2, '2026-03-06', 3) 

SELECT * FROM orders

---- Query ----
SELECT 
    c.first_name,
    c.last_name,
    o.order_id,
    o.order_date,
    o.order_status
FROM customers c
INNER JOIN orders o 
    ON c.customer_id = o.customer_id
WHERE o.order_status = 1 OR o.order_status = 4
ORDER BY o.order_date DESC


---- 2. Problem -----------

-- Brand Table --
CREATE TABLE brands (
    brand_id INT PRIMARY KEY,
    brand_name VARCHAR(100) NOT NULL
)

-- insert data into the Brand Table --
INSERT INTO brands( brand_id, brand_name) VALUES
(1, 'Nike'),
(2, 'Adidas'),
(3, 'Samsung'),
(4, 'Apple')

SELECT *  FROM brands

--- Categories Table ---
CREATE TABLE categories (
    category_id INT PRIMARY KEY,
    category_name VARCHAR(100) NOT NULL
)


-- insert data into the Categories Table ---
INSERT INTO categories (category_id, category_name) VALUES
(1, 'Shoes'),
(2, 'Phones'),
(3, 'Cloths')

SELECT * FROM categories

--- Products table ---
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL,
    brand_id INT,
    category_id INT  NOT NULL,
    model_year INT  NOT NULL,
    list_price DECIMAL(10,2),

    FOREIGN KEY (brand_id) REFERENCES brands(brand_id), 
    FOREIGN KEY (category_id) REFERENCES categories(category_id)
)

--- Insert data into the Product Table ---
    INSERT INTO products VALUES
(101, 'Nike Shoes', 1, 1, 2023, 750),
(102, 'Adidas Shoes', 2, 1, 2023, 650),
(103, 'Galaxy S23', 3, 2, 2024, 30000),
(104, 'iPhone 15', 4, 2, 2024, 1500), --- Update the list_price ---
(105, 'Sports T-Shirt', 1, 3, 2023, 300),
(106, 'Running Shorts', 2, 3, 2022, 250)

UPDATE products
SET list_price = 35000
WHERE product_id = 104

SELECT * FROM products


---  Query ------

SELECT 
    p.product_name,
    b.brand_name,
    c.category_name,
    p.model_year,
    p.list_price
FROM products p
INNER JOIN brands b 
    ON p.brand_id = b.brand_id

INNER JOIN categories c 
    ON p.category_id = c.category_id
WHERE p.list_price > 500
ORDER BY p.list_price ASC


--- 3. Problem --------

-- Store Table --
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100) NOT NULL
)

-- insert data into Store Table --
INSERT INTO stores (store_id, store_name) VALUES
(1, 'Mumbai store'),
(2, 'Delhi store'),
(3, 'Bangalore store'),
(4, 'Belagavi store')

SELECT * FROM stores

-- Order_Store Table
CREATE TABLE Order_Store (
    order_id INT PRIMARY KEY,
    store_id INT,
    order_status INT,
    order_date DATE,

    FOREIGN KEY (store_id) REFERENCES stores(store_id)
)

-- Insert data into the Order_Store Table ---
INSERT INTO Order_Store(order_id, store_id, order_status, order_date) VALUES
(101, 1, 4, '2024-01-10'),
(102, 1, 3, '2024-01-15'),
(103, 2, 4, '2024-02-01'),
(104, 3, 4, '2024-02-10')


SELECT * FROM Order_Store

-- Order_items Table ---
CREATE TABLE Order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    quantity INT,
    list_price DECIMAL(5,2),
    discount DECIMAL(4,2),

    FOREIGN KEY (order_id) REFERENCES Order_Store(order_id)
)

--- Insert Data into the Order_Items ----
INSERT INTO order_items VALUES
(1, 101, 5, 1000, 0.10),
(2, 101, 2, 500, 0.05),
(3, 103, 3, 2000, 0.15),
(4, 104, 4, 1500, 0.10),
(5, 102, 2, 800, 0.05)  

SELECT * FROM Order_items

---- Query ---

SELECT 
    s.store_name,
    SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS total_sales
FROM stores s
INNER JOIN Order_Store os 
    ON s.store_id = os.store_id

INNER JOIN Order_items oi 
    ON os.order_id = oi.order_id
WHERE os.order_status = 4
GROUP BY s.store_name
ORDER BY total_sales DESC

-------------------------------------------










