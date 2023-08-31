// JSON data of all products
let productListUrl =
    "https://my-json-server.typicode.com/pavan-kumar2/Swag_of_India-Product_list_page-Products_data/db";
let productList;
let cards = "";
let reviews = "";
let lowStar = 0;
let i = 0;

// calling the backend
async function loadProducts(productListUrl) {
    fetch(productListUrl)
        // javascript object notation
        .then((data) => data.json())
        .then((json) => {
            productList = json;
            productList.products.forEach((product) => {
                cards = `<div class="col-lg-4 col-md-6 col-12 card-container pad-sm-card pad-left-right-5">
                                    <div class="card mb-4 shadow-sm d-flex align-items-center justify-content-center"
                                        id="${product.id}">
                                        <div class="product-img">
                                            <img src="images/${
                                              product.source
                                            }.png" alt="${
          product.imageName
        }" role="img"
                                                aria-label="product-image">
                                        </div>
                                        <div class="product-view">
                                            <div class="row">
                                                <div class="col-4 wishlist" onclick="wishlist.addToWishlist('${encodeURI(
                                                  JSON.stringify(product)
                                                )}')"><img src="images/Group 2579.png" alt="wishlist"></div>
                                                <div class="col-4 view" onclick="productView.addToProductView('${encodeURI(
                                                  JSON.stringify(product)
                                                )}')"><a href="./product_view.html"><img src="images/Group 2580.png" alt="view"></a></div>
                                                <div class="col-4 cart" onclick="cart.addToCart('${encodeURI(
                                                  JSON.stringify(product)
                                                )}')"><img src="images/Group 2581.png" alt="cart"></div>
                                            </div>
                                        </div>
                                        <div class="card-body card-box">
                                            <h6>${product.name}</h6>
                                            <div class="product-cost"><span>Rs ${
                                              product.priceAfterDiscount
                                            } </span><span>Rs${
          product.price
        }</span><span>
                                                    (${product.offers}
                                                    Off)</span></div>
                                            <div class="ratings">
                                                <ul>`;
                // product ratings
                lowStar = 5 - Math.floor(product.ratings);

                for (i = 1; i <= Math.floor(product.ratings); i++) {
                    reviews += '<li><i class="fas fa-star"></i></li>';
                }
                for (i = 1; i <= lowStar; i++) {
                    reviews += '<li><i class="far fa-star"></i></li>';
                }

                cards += reviews;
                reviews = "";
                cards += `</ul>
                                            </diva
                                        </div>
                                    </div>
                                </div>`;
                document.querySelector("#wrap-products").innerHTML += cards;
            });

            // when the page load all icons will hide
            document
                .querySelectorAll("div[id^='product']")
                .forEach((productElement) => {
                    productElement.querySelector(".product-view").classList.add("hide");
                });

            // when mouse over on each product all icons will show and product image get blur
            document.querySelectorAll("div[id^='product']").forEach((product) => {
                product.addEventListener("mouseover", (event) => {
                    product.querySelector(".product-img").classList.add("blur");
                    product.querySelector(".product-view").classList.remove("hide");

                    // this will active when mousehover and mouseout from cart icon
                    document.querySelectorAll(".cart").forEach((cart) => {
                        cart.addEventListener("mouseover", () => {
                            if (cart.childNodes[0].hasAttribute("src")) {
                                cart.childNodes[0].setAttribute("src", "images/Group 2584.png");
                            }
                        });
                        cart.addEventListener("mouseout", () => {
                            if (cart.childNodes[0].hasAttribute("src")) {
                                cart.childNodes[0].setAttribute("src", "images/Group 2581.png");
                            }
                        });
                    });

                    // this will active when mousehover and mouse out from view icon
                    document.querySelectorAll(".view").forEach((view) => {
                        view.addEventListener("mouseover", () => {
                            if (view.childNodes[0].childNodes[0].hasAttribute("src")) {
                                view.childNodes[0].childNodes[0].setAttribute(
                                    "src",
                                    "images/Group 2583.png"
                                );
                            }
                        });

                        view.addEventListener("mouseout", () => {
                            if (view.childNodes[0].childNodes[0].hasAttribute("src")) {
                                view.childNodes[0].childNodes[0].setAttribute(
                                    "src",
                                    "images/Group 2580.png"
                                );
                            }
                        });
                    });

                    // this will active when mousehover and mouseout from wishlist icon
                    document.querySelectorAll(".wishlist").forEach((wishlist) => {
                        wishlist.addEventListener("mouseover", () => {
                            if (wishlist.childNodes[0].hasAttribute("src")) {
                                wishlist.childNodes[0].setAttribute(
                                    "src",
                                    "images/Group 2582.png"
                                );
                            }
                        });
                        wishlist.addEventListener("mouseout", () => {
                            if (wishlist.childNodes[0].hasAttribute("src")) {
                                wishlist.childNodes[0].setAttribute(
                                    "src",
                                    "images/Group 2579.png"
                                );
                            }
                        });
                    });
                });

                // this is used for when mouse out from prdoucts images get original style
                product.addEventListener("mouseout", (event) => {
                    product.querySelector(".product-img").classList.remove("blur");
                    product.querySelector(".product-view").classList.add("hide");
                });
            });

            //showing product index number in-between products
            let wrapProducts = document.getElementById("wrap-products");

            let productItem = wrapProducts.children[11];
            let indexProducts = `<div class="col-12 product-showing">
                                <div class="d-flex align-items-center justify-content-center">
                                  <h6>Showing 13-25 out of 76 items</h6>
                                </div>
                            </div>`;
            productItem.insertAdjacentHTML("afterend", indexProducts);
        });
}
loadProducts(productListUrl);

renderCartItems();
// Header navigation bar “sticky”
window.addEventListener("scroll", function () {
    var stickyHeader = document.getElementById("stickyHeader");
    var headerOffsetTop = stickyHeader.offsetTop;

    if (window.pageYOffset > headerOffsetTop) {
        stickyHeader.classList.add("sticky-scroll");
    } else {
        stickyHeader.classList.remove("sticky-scroll");
    }
});

// With change in dropdown value, change the flag and the support contact number
function countriesFunction() {
    var countriesList = document.getElementById("countriesList");
    var value = countriesList.options[countriesList.selectedIndex].value;

    if (value == "india") {
        document.getElementById("selector-img").src = "images/india.png";
        document.getElementById("contact-no").href = "tel:+91 9838203720";
        document.getElementById("contact-no").innerHTML =
            "<img src='images/Group 2559.png' alt='contact'> +91 9838203720";
    } else if (value == "usa") {
        document.getElementById("selector-img").src = "images/Group 2560.png";
        document.getElementById("contact-no").href = "tel:+1 123 7654321";
        document.getElementById("contact-no").innerHTML =
            "<img src='images/Group 2559.png' alt='contact'> +1 123 7654321";
    } else if (value == "uk") {
        document.getElementById("selector-img").src = "images/UK.png";
        document.getElementById("contact-no").href = "tel:+44 1234567890";
        document.getElementById("contact-no").innerHTML =
            "<img src='images/Group 2559.png' alt='contact'> +44 1234567890";
    } else {
        document.getElementById("selector-img").src = "images/Germany.png";
        document.getElementById("contact-no").href = "tel:+12 0123456789";
        document.getElementById("contact-no").innerHTML =
            "<img src='images/Group 2559.png' alt='contact'> +12 0123456789";
    }
}
// the blue button on bottom to reach the top of the website again
var scrollTopBtn = document.getElementById("scrollTopBtn");

window.onscroll = function () {
    scrollFunction();
};

function scrollFunction() {
    if (document.documentElement.scrollTop > 100) {
        scrollTopBtn.style.display = "block";
    } else {
        scrollTopBtn.style.display = "none";
    }
}

function scrollTopFunction() {
    window.scroll({
        top: 0,
        left: 0,
        behavior: "smooth",
    });
}