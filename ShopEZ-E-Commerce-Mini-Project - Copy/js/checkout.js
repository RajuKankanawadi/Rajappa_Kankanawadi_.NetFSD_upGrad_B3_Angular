$(function(){

let cart=getCart()
let html=""
let total=0

cart.forEach(x=>{
total+=x.price*(x.qty||1)
html+=`<li>${x.name} x ${x.qty}</li>`
})

$("#summary").html(html)

$("#form").submit(function(e){
e.preventDefault()

alert("Order placed Successfully.")
localStorage.removeItem("cart")

window.location="index.html"
})

})