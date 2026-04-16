
$(function () {
    let cart = getCart();

    function renderCart() {
        let html = "";
        let subtotal = 0;
        let totalItems = 0;
        let deliveryCharge = 0;
        let discount = 0;
        let grandTotal = 0;

        if (cart.length === 0) {
            html = `
                <tr>
                    <td colspan="5" class="text-center text-danger fw-bold py-4">
                        Your cart is Empty !! Please add Product into the Cart.
                    </td>
                </tr>
            `;

            $("#cartData").html(html);
            $("#subtotal").text("0");
            $("#discount").text("0");
            $("#deliveryCharge").text("0");
            $("#total").text("0");
            $("#itemCount").text("0");
            $("#checkoutBtn").prop("disabled", true);
            return;
        }

        cart.forEach((item, index) => {
            let qty = parseInt(item.qty) || 1;
            let rowTotal = item.price * qty;

            subtotal += rowTotal;
            totalItems += qty;

            html += `
                <tr>
                    <td class="table-warning fw-bold">${item.name}</td>
                    <td class="table-warning fw-bold"> ${item.price} Rs</td>
                    <td class="table-warning fw-bold">
                        <input 
                            type="number" 
                            min="1" 
                            value="${qty}" 
                            class="form-control text-center qty-input" 
                            data-index="${index}">
                    </td>
                    <td class="fw-bold table-warning text-success"> ${rowTotal.toFixed(2)} Rs</td>
                    <td class="table-warning">
                        <button class="btn  btn-danger btn-sm remove-btn" data-index="${index}">
                            Remove
                        </button>
                    </td>
                </tr>
            `;
        });

        if (subtotal >= 10000) {
            discount = subtotal * 0.10;
        } else if (subtotal >= 5000) {
            discount = subtotal * 0.05;
        }

        if (subtotal < 10000) {
            deliveryCharge = 200;
        } else {
            deliveryCharge = 50 ;
        }

        grandTotal = subtotal - discount + deliveryCharge;

        html += `
            <tr class="table-info fw-bold">
                <td colspan="3" class="text-end">Subtotal</td>
                <td> ${subtotal.toFixed(2)} Rs</td>
                <td>-</td>
            </tr>

            <tr class="table-success fw-bold">
                <td colspan="3" class="text-end">Discount</td>
                <td> ${discount.toFixed(2)} Rs</td>
                <td>-</td>
            </tr>

            <tr class="table-secondary fw-bold">
                <td colspan="3" class="text-end">Delivery Charge</td>
                <td>${deliveryCharge.toFixed(2)} Rs</td>
                <td>-</td>
            </tr>

            <tr class="table-primary fw-bold">
                <td colspan="3" class="text-end">Grand Total</td>
                <td> ${ grandTotal.toFixed(2)} Rs</td>
                <td>-</td>
            </tr>
        `;

        $("#cartData").html(html);
        $("#subtotal").text(subtotal.toFixed(2) + " Rs");
        $("#discount").text(discount.toFixed(2) + " Rs");
        $("#deliveryCharge").text(deliveryCharge.toFixed(2) + " Rs");
        $("#total").text(grandTotal.toFixed(2) + " Rs");
        $("#itemCount").text(totalItems);
        $("#checkoutBtn").prop("disabled", false);

        updateCount();
    }

    $(document).on("change", ".qty-input", function () {
        let index = $(this).data("index");
        let quantity = parseInt($(this).val());

        if (isNaN(quantity) || quantity < 1) {
            quantity = 1;
            $(this).val(1);
        }

        cart[index].qty = quantity;
        saveCart(cart);
        renderCart();
    });

    $(document).on("click", ".remove-btn", function () {
        let index = $(this).data("index");

        if (confirm("Are you sure you want to remove this item?")) {
            cart.splice(index, 1);
            saveCart(cart);
            renderCart();
        }
    });

      $("#checkoutBtn").click(function () {
        if (cart.length > 0) {
            window.location.href = "checkout.html";
        }
    });
    renderCart();
});