$(function () {

    $.getJSON("data/products.json", function (products) {

        let currentPage = 1;
        const perPage = 6; // products per page

        function displayPage(page, list) {
            let html = "";
            let start = (page - 1) * perPage;
            let end = start + perPage;
            let pageItems = list.slice(start, end);

            pageItems.forEach(p => {
                html += `
                <div class="col-md-4 mb-3">
                    <div class="card">
                        <img src="${p.image}" class="custom-img">
                        <div class="card-body">
                            <h6>Product : ${p.name}</h6>
                            <p>Rating (out of 5):  ${p.rating}</p>
                            <p class="price">Price:${p.price} Rs.</p>
                            <a href="product-details.html?id=${p.id}" class="btn btn-primary btn-sm">View</a>
                            <button class="btn btn-success btn-sm add" data-id="${p.id}">Add</button>
                        </div>
                    </div>
                </div>`;
            });

            $("#productList").html(html);
            setupPagination(list);
        }

        function setupPagination(list) {
            let pages = Math.ceil(list.length / perPage);
            let html = "";
            for (let i = 1; i <= pages; i++) {
                html += `<li class="page-item ${i === currentPage ? 'active' : ''}">
                        <a class="page-link" href="#">${i}</a>
                        </li>`;
            }
            $("#pagination").html(html);
        }

        // Pagination click
        $(document).on("click", ".page-link", function (e) {
            e.preventDefault();
            currentPage = parseInt($(this).text());
            displayPage(currentPage, filteredProducts);
        });

        // SEARCH + FILTER
        let filteredProducts = products;

        $("#search").keyup(function () {
            let v = $(this).val().toLowerCase();
            filteredProducts = products.filter(p => p.name.toLowerCase().includes(v));
            currentPage = 1;
            displayPage(currentPage, filteredProducts);
        });

        $("#category").change(function () {
            let c = $(this).val();
            if (c === "all") filteredProducts = products;
            else filteredProducts = products.filter(p => p.category === c);
            currentPage = 1;
            displayPage(currentPage, filteredProducts);
        });

        // ADD TO CART
        $(document).on("click", ".add", function () {
            let id = $(this).data("id");
            let cart = getCart();
            let item = products.find(p => p.id == id);
            item.qty = 1;
            cart.push(item);
            saveCart(cart);
            alert("Added to Cart");
        });

        // INITIAL LOAD
        displayPage(currentPage, products);

        // Infinite Scroll
        $(window).scroll(function () {
            if ($(window).scrollTop() + $(window).height() > $(document).height() - 100) {
                if ((currentPage * perPage) < filteredProducts.length) {
                    currentPage++;
                    let start = (currentPage - 1) * perPage;
                    let end = start + perPage;
                    let pageItems = filteredProducts.slice(start, end);
                    pageItems.forEach(p => {
                        $("#productList").append(`
                        <div class="col-md-4 mb-4">
                            <div class="card">
                                <img src="${p.image}" class="custom-img">
                                <div class="card-body">
                                    <h6>Product: ${p.name}</h6>
                                    <p>Rating(out of 5):  ${p.rating}</p>
                                    <p class="price">Price: ${p.price} Rs.</p>
                                    <a href="product-details.html?id=${p.id}" class="btn btn-primary btn-sm">View</a>
                                    <button class="btn btn-success btn-sm add" data-id="${p.id}">Add</button>
                                </div>
                            </div>
                        </div>`);
                    });
                }
            }
        });

    });

});