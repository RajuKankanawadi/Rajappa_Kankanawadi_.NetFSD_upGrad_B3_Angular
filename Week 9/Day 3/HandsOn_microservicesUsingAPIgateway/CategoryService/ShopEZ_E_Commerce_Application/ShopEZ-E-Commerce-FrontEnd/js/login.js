$(function() {
    $("#loginForm").submit(function(e){
        e.preventDefault();

        let email = $("#email").val().trim();
        let password = $("#password").val().trim();
        let isValid = true;

        // Email validation
        const emailPattern = /^[^ ]+@[^ ]+\.[a-z]{2,3}$/;
        if(!emailPattern.test(email)) {
            $("#email").addClass("is-invalid");
            isValid = false;
        } else {
            $("#email").removeClass("is-invalid");
        }

        // Password validation
        if(password.length < 8) {
            $("#password").addClass("is-invalid");
            isValid = false;
        } else {
            $("#password").removeClass("is-invalid");
        }

        if(isValid){
            alert("Login Successful!");
            // Redirect to home page after login
            window.location.href = "index.html";
        }
    });
});