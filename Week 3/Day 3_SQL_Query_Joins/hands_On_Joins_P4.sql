USE EventDB_1

-- Products Table
CREATE TABLE products (
    product_id INT PRIMARY KEY,
    product_name VARCHAR(100) NOT NULL
);

-- Stores Table
CREATE TABLE stores (
    store_id INT PRIMARY KEY,
    store_name VARCHAR(100) NOT NULL
);

-- Stocks Table (Available Stock per Store per Product)
CREATE TABLE stocks (
    stock_id INT PRIMARY KEY,
    product_id INT,
    store_id INT,
    quantity INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

-- Orders Table
CREATE TABLE orders (
    order_id INT PRIMARY KEY,
    order_date DATE
);

-- Order Items Table (Sold Products)
CREATE TABLE order_items (
    order_item_id INT PRIMARY KEY,
    order_id INT,
    product_id INT,
    store_id INT,
    quantity INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (store_id) REFERENCES stores(store_id)
);

---- Insert Into Data respective Tables -------

-- Products
INSERT INTO products VALUES
(1, 'Laptop'),
(2, 'Mobile'),
(3, 'Headphones');

-- Stores
INSERT INTO stores VALUES
(1, 'Mumbai Store'),
(2, 'Delhi Store');

-- Stocks
INSERT INTO stocks VALUES
(1, 1, 1, 50),   -- Laptop in Mumbai
(2, 2, 1, 100),  -- Mobile in Mumbai
(3, 3, 1, 80),   -- Headphones in Mumbai
(4, 1, 2, 40),   -- Laptop in Delhi
(5, 2, 2, 70);   -- Mobile in Delhi
-- Notice: Headphones not stocked in Delhi

-- Orders
INSERT INTO orders VALUES
(1, '2026-03-01'),
(2, '2026-03-02');

-- Order Items
INSERT INTO order_items VALUES
(1, 1, 1, 1, 5),  -- 5 Laptops sold in Mumbai
(2, 1, 2, 1, 10), -- 10 Mobiles sold in Mumbai
(3, 2, 1, 2, 3);  -- 3 Laptops sold in Delhi
-- Notice: Headphones not sold

---- Read Operation -----

SELECT * FROM stocks

SELECT * FROM stores

SELECT * FROM orders

SELECT * FROM order_items

SELECT * FROM products

---- Query -----

SELECT 
    p.product_name,
    s.store_name,
    st.quantity AS available_stock,
    ISNULL(SUM(oi.quantity), 0) AS total_quantity_sold
FROM stocks st

INNER JOIN products p 
    ON st.product_id = p.product_id

INNER JOIN stores s 
    ON st.store_id = s.store_id

LEFT JOIN order_items oi 
    ON st.product_id = oi.product_id
    AND st.store_id = oi.store_id

GROUP BY 
    p.product_name,
    s.store_name,
    st.quantity

ORDER BY 
    p.product_name;
