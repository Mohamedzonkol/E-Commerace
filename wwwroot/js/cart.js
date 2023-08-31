const cart = {
    //adding product to cart
    addToCart: function (product) {
        let newProduct = product;
        if (typeof product === "string") {
            newProduct = JSON.parse(decodeURI(product));
        }
        const myCartItems = this.getAllItems();

        const filteredItem = myCartItems.filter((item) => item.id == newProduct.id);

        if (filteredItem.length === 1) {
            filteredItem[0].qty += 1;
        } else {
            myCartItems.unshift({
                ...newProduct,
                qty: 1,
            });
        }

        localStorage.setItem("MY_CART", JSON.stringify(myCartItems));
    },

    //remove product from add to cart items
    removeFromCart: function (id) {
        const myCartItems = this.getAllItems();
        const filteredItem = myCartItems.filter((item) => item.id !== id);

        localStorage.setItem("MY_CART", JSON.stringify(filteredItem));
    },

    getAllItems: function () {
        return JSON.parse(localStorage.getItem("MY_CART")) || [];
    },

    removeAllItems: function () {
        localStorage.removeItem("MY_CART");
    },

    //incremnting quantity of add to cart product
    incrementQty: function (id) {
        const myCartItems = this.getAllItems();
        const filteredItem = myCartItems.filter((item) => item.id == id);

        if (filteredItem.length === 1 && filteredItem[0].qty < 10) {
            filteredItem[0].qty += 1;
        }

        localStorage.setItem("MY_CART", JSON.stringify(myCartItems));
    },

    //decrementing quantity of add to cart product
    decrementQty: function (id) {
        const myCartItems = this.getAllItems();
        const filteredItem = myCartItems.filter((item) => item.id == id);

        if (filteredItem.length === 1 && filteredItem[0].qty > 1) {
            filteredItem[0].qty -= 1;
        }

        localStorage.setItem("MY_CART", JSON.stringify(myCartItems));
    },
};

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