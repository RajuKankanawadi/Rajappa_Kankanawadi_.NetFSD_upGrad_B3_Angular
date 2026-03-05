
    USE EventDB
--- 1 Problem ---

--- Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').---

    SELECT 
    CONCAT(p.product_name, ' (', p.model_year, ')') AS product_model,
    p.list_price,

    -- Compare each product’s price with the average price of products in the same category using a nested query.

    (SELECT AVG(p2.list_price)
     FROM products p2
     WHERE p2.category_id = p.category_id) AS category_avg_price,

    -- . Show calculated difference between product price and category average.

    p.list_price - 
    (SELECT AVG(p3.list_price)
     FROM products p3
     WHERE p3.category_id = p.category_id) AS price_difference
     FROM products p

     --. Show calculated difference between product price and category average.

     WHERE p.list_price >
    (SELECT AVG(p4.list_price)
     FROM products p4
     WHERE p4.category_id = p.category_id);

---------- 2. Problem -----------------------------------------------------------

     -- Customers WITH Orders Display full name using string concatenation..

    SELECT 
    CONCAT(c.first_name, ' ', c.last_name) AS full_name,

    -- Nested query for total order value ---
    (
        SELECT SUM(o2.order_status)
        FROM orders o2
        WHERE o2.customer_id = c.customer_id
    ) AS total_order_value,

    --Classify customers using conditional logic:
   --'Premium' if total order value > 10000
   --'Regular' if total order value between 5000 and 10000
   --'Basic' if total order value < 5000

    CASE
        WHEN (
            SELECT SUM(o3.order_status)
            FROM orders o3
            WHERE o3.customer_id = c.customer_id
        ) > 10000 THEN 'Premium'

        WHEN (
            SELECT SUM(o3.order_status)
            FROM orders o3
            WHERE o3.customer_id = c.customer_id
        ) BETWEEN 5000 AND 10000 THEN 'Regular'

        ELSE 'Basic'
    END AS customer_type

    FROM customers c
    INNER JOIN orders o
    ON c.customer_id = o.customer_id

    GROUP BY c.customer_id, c.first_name, c.last_name


    UNION


    -- Customers WITHOUT Orders

    SELECT 
        CONCAT(c.first_name, ' ', c.last_name) AS full_name,
        NULL AS total_order_value,
        'No Orders' AS customer_type
    FROM customers c
    WHERE c.customer_id NOT IN
    (
        SELECT customer_id FROM orders
    );


    -- 3. Problem -------------------------------------------------------------

    USE EventDB_1

    -- 1. Identify Products Sold in Each Store
    -- (Using Nested Query in FROM)
    
    SELECT 
        s.store_name,
        p.product_name,
        sales.total_quantity_sold
    FROM
    (
        SELECT 
            store_id,
            product_id,
            SUM(quantity) AS total_quantity_sold
        FROM order_items
        GROUP BY store_id, product_id
    ) AS sales

    INNER JOIN stores s
        ON sales.store_id = s.store_id

    INNER JOIN products p
        ON sales.product_id = p.product_id;



    -- 2. Products Sold but Currently Out of Stock
    -- (Using INTERSECT)
 
    SELECT product_id
    FROM order_items

    INTERSECT

    SELECT product_id
    FROM stocks
    WHERE quantity = 0


    -- 3. Products Sold but Not Present in Stock Table
    -- (Using EXCEPT)
   
    SELECT product_id
    FROM order_items

    EXCEPT

    SELECT product_id
    FROM stocks;



    -- 4. Store Performance Report
    -- Display store_name, product_name, total quantity sold
   
    SELECT 
-- Level-2: Problem 4 – Order Cleanup and Data Maintenance

        s.store_name,
        p.product_name,
        SUM(oi.quantity) AS total_quantity_sold
    FROM order_items oi

    INNER JOIN stores s
        ON oi.store_id = s.store_id

    INNER JOIN products p
        ON oi.product_id = p.product_id

    GROUP BY 
        s.store_name,
        p.product_name;


    -- 5. Revenue Calc
    
   
    SELECT 
        s.store_name,
        p.product_name,
        SUM(oi.quantity) AS total_quantity_sold,
        SUM(oi.quantity * 1000) AS total_revenue
    FROM order_items oi

    INNER JOIN stores s
        ON oi.store_id = s.store_id

    INNER JOIN products p
        ON oi.product_id = p.product_id

    GROUP BY 
        s.store_name,
        p.product_name

    ORDER BY total_revenue DESC;


    -- 6. Update Stock for Discontinued Products
   
    UPDATE stocks
    SET quantity = 3 -- 0
    WHERE product_id = 3;

    SELECT * FROM stocks

    



