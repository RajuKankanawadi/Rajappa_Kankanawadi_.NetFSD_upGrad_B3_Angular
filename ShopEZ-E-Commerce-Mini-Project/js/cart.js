$(function(){

let cart=getCart()
let html=""
let total=0

cart.forEach((x,i)=>{
total+=x.price*(x.qty||1)

html+=`
<tr>
<td>${x.name}</td>
<td>${x.qty}</td>
<td>${x.price}</td>
<td><button class="remove btn btn-danger" data-i="${i}">Remove</button></td>
</tr>`
})

$("#data").html(html)
$("#total").text(total)

$(document).on("click",".remove",function(){
let i=$(this).data("i")
cart.splice(i,1)
saveCart(cart)
location.reload()
})

})
