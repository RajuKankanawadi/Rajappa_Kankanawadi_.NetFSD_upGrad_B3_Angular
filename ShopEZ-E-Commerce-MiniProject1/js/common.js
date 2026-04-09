// Get cart
function getCart() {
    return JSON.parse(localStorage.getItem("cart")) || [];
}

// Save cart
function saveCart(cart) {
    localStorage.setItem("cart", JSON.stringify(cart));
}

// Update cart count
function updateCount() {
    let cart = getCart();
    let el = document.getElementById("cartCount");
    if(el) el.innerText = cart.reduce((sum, item) => sum + (item.qty || 1), 0);
}

updateCount();