# ShopEZ – E-Commerce Frontend Application

## Author
Rajappa Kankanawadi
Batch 3

---

## Project Overview
ShopEZ is a frontend-only e-commerce web application built using HTML, CSS, JavaScript, Bootstrap, and jQuery. 

The application allows users to browse products, view detailed product information, add items to a shopping cart, remove items from the cart, and simulate a checkout process.

All data is handled on the client side using JSON and LocalStorage without any backend server.

---

## Features

- Product listing page
- Product details page
- Add to cart functionality
- Remove items from cart
- Cart total calculation
- Checkout simulation
- Responsive design using Bootstrap
- Cart persistence using LocalStorage

---

## Technologies Used

- HTML5
- CSS3
- JavaScript (ES6)
- Bootstrap 5
- jQuery (CDN)
- JSON (for product data)
- LocalStorage (for cart data)

---

## Project Structure

```
ShopEZ-Frontend
│
├── index.html
├── products.html
├── product-details.html
├── cart.html
├── checkout.html
│
├── css/
│   └── styles.css
│
├── js/
│   ├── products.js
│   ├── cart.js
│   ├── checkout.js
│   └── common.js
│
├── data/
│   └── products.json
│
├── images/
│   ├── laptop.png
│   ├── smartphone.jpg
│   ├── headphone.jpg
│   ├── smartwatch.jpg
│   ├── tablet.jpg
│   ├── camera.jpg
│   └── icon.jpg
```
---

## How to Run the Project

1. Download or clone the project folder
2. Open the project in VS Code
3. Install Live Server extension
4. Right-click on `index.html`
5. Click on "Open with Live Server"
6. The application will run in your browser

---

## Application Flow

Home Page  
→ Products Page  
→ Product Details  
→ Add to Cart  
→ Cart Page  
→ Checkout Page  

---

## File Description

### HTML Files
- `index.html` → Displays featured products
- `products.html` → Displays all products
- `product-details.html` → Shows detailed product information
- `cart.html` → Displays selected cart items
- `checkout.html` → Handles checkout process

### JavaScript Files
- `products.js` → Loads and displays products from JSON
- `cart.js` → Handles cart operations (add/remove/display)
- `checkout.js` → Handles checkout logic and validation
- `common.js` → Handles LocalStorage and cart count

### CSS File
- `styles.css` → Handles styling, layout, and responsiveness

### Data File
- `products.json` → Stores product details in JSON format

---

## Data Handling

- Product data is loaded from a JSON file using jQuery
- Cart data is stored in LocalStorage
- Cart persists even after page refresh

---

## UI Components Used

- Bootstrap Navbar
- Cards for product display
- Grid system for layout
- Buttons and forms
- Responsive design

---

## Conclusion

This project demonstrates the implementation of a complete frontend e-commerce workflow including product display, cart management, and checkout simulation using client-side technologies.

