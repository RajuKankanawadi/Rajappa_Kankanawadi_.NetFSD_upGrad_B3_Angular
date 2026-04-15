$(function() {
    $.getJSON("data/products.json", function(products) {

        let id = new URLSearchParams(location.search).get("id");
        let p = products.find(x => x.id == id);
        if(!p) {
            alert("Product not found!");
            window.location = "products.html";
            return;
        }

        // Set image
        $("#img").attr("src", p.image);

            // Add labels + values
        $("#name").html("<b>Product Name :</b> " + p.name);
        $("#desc").html("<b>Description :</b> " + p.description);
        $("#price").html("<b>Price :</b> " + p.price + " Rs.");

        // Star Rating
        function getStars(rating){
            let full = Math.floor(rating);
            let half = rating - full >= 0.5 ? 1 : 0;
            let empty = 5 - full - half;
            return "★".repeat(full) + (half ?"☆" : "") + "☆ ".repeat(empty);
        }
        $("#stars").html("<b>Rating : </b> " + (getStars(p.rating)));

        // Quantity input change validation
        $("#qty").val(1);
        $("#qty").on("input", function(){
            let val = parseInt($(this).val());
            if(isNaN(val) || val<1){
                $(this).val(1);
            }
        });

        // Add to cart
        $("#add").click(function(){
            let cart = getCart();
            let existing = cart.find(x => x.id == p.id);
            let qty = parseInt($("#qty").val());
            if(existing){
                existing.qty += qty;
            } else {
                p.qty = qty;
                cart.push(p);
            }
            saveCart(cart);
            updateCount();
            alert("Added to Cart!");
        });
    });
});