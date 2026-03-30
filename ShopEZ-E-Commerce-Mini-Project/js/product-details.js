$(function(){

$.getJSON("data/products.json", function(products){

let id=new URLSearchParams(location.search).get("id")
let p=products.find(x=>x.id==id)

 // Set image
$("#img").attr("src", p.image);

// Add labels + values
$("#name").html("<b>Product Name :</b> " + p.name);
$("#desc").html("<b>Product Description :</b> " + p.description);
$("#price").html("<b>Product Price (Rs) :</b> " + p.price);

$("#add").click(function(){
let cart=getCart()
p.qty=1
cart.push(p)
saveCart(cart)
alert("Added")
})

})

})