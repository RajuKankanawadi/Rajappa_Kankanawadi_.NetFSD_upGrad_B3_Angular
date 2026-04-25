"use strict";
// Generic Function
function getFirstElement(items) {
    return items[0];
}
// Generic Class
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
// User Data
const userManager = new DataManager();
userManager.add({ id: 1, name: "Raju" });
userManager.add({ id: 2, name: "Amit" });
// Product Data
const productManager = new DataManager();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });
// Display Data
console.log("Users:", userManager.getAll());
console.log("Products:", productManager.getAll());
console.log("First User:", getFirstElement(userManager.getAll()));
console.log("First Product:", getFirstElement(productManager.getAll()));
