// checkout.js
$(function () {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];

    // Redirect if cart is empty
    if (cart.length === 0) {
        alert("Your cart is empty!");
        window.location.href = "cart.html";
    }

    // Form Validation
    $("#checkoutForm").submit(function (e) {
        e.preventDefault();

        let isValid = true;

        // Clear previous errors
        $(".error").text("");

        let fullName = $("#fullName").val().trim();
        let email = $("#email").val().trim();
        let phone = $("#phone").val().trim();
        let city = $("#city").val().trim();
        let address = $("#address").val().trim();
        let pincode = $("#pincode").val().trim();
        let paymentMethod = $("#paymentMethod").val();

        // Name Validation
        if (fullName.length < 3) {
            $("#nameError").text("Full name must be at least 3 characters");
            isValid = false;
        }

        // Email Validation
        let emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(email)) {
            $("#emailError").text("Enter a valid email address");
            isValid = false;
        }

        // Phone Validation
        let phonePattern = /^[0-9]{10}$/;
        if (!phonePattern.test(phone)) {
            $("#phoneError").text("Enter a valid 10-digit mobile number");
            isValid = false;
        }

        // City Validation
        if (city.length < 4) {
            $("#cityError").text("City Name must be at least 4 characters");
            isValid = false;
        }

        // Address Validation
        if (address.length < 10) {
            $("#addressError").text("Address Name must be at least 10 characters");
            isValid = false;
        }

        // Pincode Validation
        let pincodePattern = /^[0-9]{6}$/;
        if (!pincodePattern.test(pincode)) {
            $("#pincodeError").text("Enter a valid 6-digit pincode");
            isValid = false;
        }

        // Payment Validation
        if (paymentMethod === "") {
            $("#paymentError").text("Please select a payment method");
            isValid = false;
        }

        // Success
        if (isValid) {
            alert("Order placed successfully!");

            // Clear cart
            localStorage.removeItem("cart");

            // Redirect to home page
            window.location.href = "index.html";
        }
    });
});