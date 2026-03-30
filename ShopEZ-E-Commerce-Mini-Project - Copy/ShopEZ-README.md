### **ShopEZ - E-Commerce Frontend Project**

**\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~**



#### **Project Overview:**

**\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~**



ShopEZ is a dynamic, responsive, and interactive e-commerce frontend project built with HTML, CSS, JavaScript, jQuery, and Bootstrap. It simulates an online shopping experience with features like product listing, product details, cart management, checkout, search, filters, pagination, and infinite scroll.



This project is designed to demonstrate frontend development skills using static JSON as the data source.



#### **Project Structure:** 

**\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~**



ShopEZ-E-Commerce-Mini-Project /

│

├── index.html                             # Home page with featured products

├── products.html                       # All products page with search, filters, pagination

├── product-details.html           # Detailed page for each product

├── cart.html                                # Shopping cart page

├── checkout.html                      # Checkout page with order summary

│

├── css/

│   └── styles.css                         # Project styling

│

├── js/

│   ├── common.js                      # Cart management, cart count

│   ├── products.js                      # Products listing, search, filter, pagination, infinite scroll

│   ├── product-details.js          # Product detail page functionality

│   ├── cart.js                               # Cart page functionality

│   └── checkout.js                     # Checkout page functionality

│

├── data/

│   └── products.json                 # Product data (JSON)

│

└── images/                                # Product images (p1.jpg, p2.jpg … p20.jpg)





#### **Features:**

**\~\~\~\~\~\~\~\~\~\~\~\~\~**



**Home Page (index.html)**



Displays featured products in a grid layout.



Images are responsive and have hover effects.



Navigation bar links to products and cart pages.



**Products Page (products.html)**



Shows all 20 products dynamically using JSON data.



Search products by name.



Filter products by category (Electronics, Accessories).



Pagination (6 products per page).



Infinite scroll: load more products as user scrolls.



Add products to cart directly.



**Product Details Page (product-details.html)**



Dynamic display of product name, description, price, image, and rating.



Add product to cart from detail page.



**Cart Page (cart.html)**



Shows products added to the cart with quantity and price.



Remove products from the cart.



Total price calculation.



Checkout button to navigate to checkout page.



Background color and content aligned to center for better readability.



**Checkout Page (checkout.html)**



Shows order summary (product name × quantity).



Form fields for Name, Email, and Address.



On submission: displays success alert, clears cart, and redirects to home page.



Styled container with center alignment and responsive layout.



#### **Technologies Used:**

**\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~**



**Frontend:**  HTML5, CSS3, Bootstrap 5, JavaScript (ES6), jQuery



**Data:** Local JSON file (products.json)



**Styling:** Responsive design using Bootstrap grid and custom CSS



#### **How It Works:** 

**\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~**



User opens index.html → sees featured products.



User navigates to products.html → can browse all products, search, filter, and paginate.



Clicking on a product → navigates to product-details.html → shows product info and allows adding to cart.



Clicking Add to Cart → stores product in localStorage cart.



User opens cart.html → can view cart items, remove items, and see total.



Clicking Checkout → navigates to checkout.html → shows order summary and form.



Submitting checkout → clears cart and redirects to index.html.



All pages dynamically read from products.json and cart information is stored in localStorage for persistence across pages.



#### **\*\* Note: \*\***

**\~\~\~\~\~\~\~\~\~\~\~\~\~\~**



Project is fully client-side; no backend or database.



Works best in modern browsers (Chrome, Firefox, Edge).



All product images are in images/ folder.



#### **How to Run:**

**\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~\~**



Extract the  B3\_.NetAngular\_Rajappa\_ShopEZ\_ECommerceApplication.zip folder.



Open index.html in your browser (or run a local server for full functionality).



Browse products, add to cart, and test checkout workflow.



*==>* This README explains the working, structure, and usage clearly.





\------------------------------------------------------------------------------------------------------------------------THE END---------------------------------------------------------------------------------------------------------------------------------------

