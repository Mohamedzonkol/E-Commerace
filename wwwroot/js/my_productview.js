function renderProductViewItems() {
    const productViewItems = productView.getAllItems();

    const productViewContent = productViewItems.reduce((prev, curr) => {
        // product rates
        let stars = "";
        const ratings = Math.floor(curr.ratings);
        for (let i = 1; i <= 5; i++) {
            if (i <= ratings) {
                stars += '<li class="star"><i class="fas fa-star"></i></li>';
            } else {
                stars += '<li class="star"><i class="far fa-star"></i></li>';
            }
        }

        return (prev = `<section>
        <div class="row my-sm-4 my-3">

            <div class="col-md-6 col-12 pad-sm-xsm-0">
                <div class="d-flex flex-row">
                    <div class="d-flex flex-column product-views">
                        <img src="images/${curr.source}.png" alt="${
      curr.imageName
    }">
                        <img src="images/${curr.source}.png" alt="${
      curr.imageName
    }">
                        <img src="images/${curr.source}.png" alt="${
      curr.imageName
    }">
                        <img src="images/${curr.source}.png" alt="${
      curr.imageName
    }">
                    </div>
                   
                    <div class="focused-product">
                        <img src="images/${curr.source}.png" alt="${
      curr.imageName
    }">
                    </div>
                </div>
            </div>
            
            <div class="col-md-6 col-12 pad-sm-xsm-0">
                <div class="product-info">
                    <div class="product-name-rating">
                        <h5>${curr.name}</h5>
                        <div class="product-view-rating">
                            <span>
                                <ul>
                                    ${stars}
                                </ul>
                            </span>
                            <span>39,122 ratings</span>
                            <span>|</span>
                            <span>1000+ answered questions</span>
                        </div>
                    </div>

                    <div class="product-discount-off">
                        <p class="">Rs ${
                          curr.priceAfterDiscount * curr.qty
                        } <span>Rs ${curr.price * curr.qty}</span><span> (${
      curr.offers
    } Off)</span></p>
                    </div>

                    <div class="product-description">
                        <h6>Short Description</h6>
                        <p>Material: 100% Super Combed Cotton, 320 GSM bio-washed Comfortable, Soft, Convenient
                            and cozy, just how a Sweatshirt should be!<br> Style: Regular Fit, Derby Rib at Hip
                            & Wrist, Double stitched Wash
                        </p>
                    </div>

                    <div
                        class="product-size-quantity d-flex flex-row align-items-center justify-content-between">
                        <div class="select-size">
                            <h6>SELECT SIZE</h6>
                            <div class="size-number">
                                <div>39</div>
                                <div>40</div>
                                <div>42</div>
                                <div>44</div>
                            </div>
                        </div>
                        <div class="product-quantity">
                            <h6>QTY</h6>
                            <div class="d-flex align-items-center">
                                <span onclick="decrement('${curr.id}')">-</span>
                                <span>${curr.qty}</span>
                                <span onclick="increment('${curr.id}')">+</span>
                            </div>
                        </div>
                    </div>

                    <div class="product-btn-group">
                        <a href="./my_carts.html"><button onclick="moveToCart('${
                          curr.id
                        }', '${encodeURI(
      JSON.stringify(curr)
    )}')">ADD TO CART</button></a>
                        <a href="./checkout.html"><button>BUY NOW</button></a>
                        <a href="./my_wishlist.html" class="save-product"><div class="width-sm-xsm d-flex align-items-center justify-content-center" onclick="moveToWishList('${
                          curr.id
                        }', '${encodeURI(JSON.stringify(curr))}')">
                            <img src="images/Group 2579.png" alt="heart icon">
                            <img src="images/Group 2582.png" alt="heart icon">
                        </div></a>
                    </div>

                    <div class="share-socialmedia d-flex align-items-center">
                        <span>SHARE THIS</span>
                        <a href="#"><img src="images/facebook round.png" alt="facebook"></a>
                        <a href="#"><img src="images/Group 2556.png" alt="youtube"></a>
                        <a href="#"><img src="images/Group 2557.png" alt="twitter"></a>
                    </div>

                    <div class="product-delivery-support d-flex flex-row align-items-center">
                        <div>
                            <img src="./images/delivery-img.png" alt="delivery-icon">
                            <span>DELIVERY & RETURN</span>
                        </div>
                        <div>
                            <img src="./images/support-img.png" alt="support-icon">
                            <span>ONLINE SUPPORT 24/7</span>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </section>`);
    }, "");

    document.getElementById("productViewContent").innerHTML = productViewContent;

    const ratingStar = document.querySelectorAll(".star");
    // This is used for to take review div when click on review star at 0.3 seconds.
    for (x = 0; x < ratingStar.length; x++) {
        ratingStar[x].addEventListener("click", () => {
            setTimeout(reviewDiv, 300);
        });

        function reviewDiv() {
            const reviewDiv = document.getElementById("reviewDiv");
            reviewDiv.scrollIntoView({
                behavior: "smooth",
            });
        }
    }
}

function moveToWishList(id, product) {
    removeProductView(id);
    wishlist.addToWishlist(product);
}

function moveToCart(id, product) {
    removeProductView(id);
    cart.addToCart(product);
}

function increment(id) {
    productView.incrementQty(id);
    renderProductViewItems();
}

function decrement(id) {
    productView.decrementQty(id);
    renderProductViewItems();
}

function removeProductView(id) {
    productView.removeFromProductView(id);
    renderProductViewItems();
}

renderProductViewItems();

// review stars clickable and takes to reviews div of page in 0.3 second.
const productRating = document.querySelectorAll(".star");

for (x = 0; x < productRating.length; x++) {
    productRating[x].starValue = x + 1;
    ["click"].forEach(function (e) {
        productRating[x].addEventListener(e, showRating);
    });
}

function showRating(e) {
    let type = e.type;
    let starValue = this.starValue;

    productRating.forEach(function (elem, ind) {
        if (type === "click") {
            if (ind < starValue) {
                elem.innerHTML = "<i class='fas fa-star'></i>";
            } else {
                elem.innerHTML = "<i class='far fa-star'></i>";
            }
        }
    });
}

//  products scrolling on click of left and right button.
let scrollingProducts = document.getElementById("scrollingProducts");
let product = scrollingProducts.getElementsByClassName("product");

let btnRight = document.querySelector(".btn-right");
btnRight.addEventListener("click", () => {
    scrollingProducts.append(product[0]);
});

let btnLeft = document.querySelector(".btn-left");
btnLeft.addEventListener("click", () => {
    scrollingProducts.prepend(product[product.length - 1]);
});

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
        document.getElementById("selector-img").src = "images/india.png"
        document.getElementById("contact-no").href = "tel:+91 9838203720"
        document.getElementById("contact-no").innerHTML = "<img src='images/Group 2559.png' alt='contact'> +91 9838203720"
    } else if (value == "usa") {
        document.getElementById("selector-img").src = "images/Group 2560.png"
        document.getElementById("contact-no").href = "tel:+1 123 7654321"
        document.getElementById("contact-no").innerHTML = "<img src='images/Group 2559.png' alt='contact'> +1 123 7654321"
    } else if (value == "uk") {
        document.getElementById("selector-img").src = "images/UK.png"
        document.getElementById("contact-no").href = "tel:+44 1234567890"
        document.getElementById("contact-no").innerHTML = "<img src='images/Group 2559.png' alt='contact'> +44 1234567890"
    } else {
        document.getElementById("selector-img").src = "images/Germany.png"
        document.getElementById("contact-no").href = "tel:+12 0123456789"
        document.getElementById("contact-no").innerHTML = "<img src='images/Group 2559.png' alt='contact'> +12 0123456789"
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