function renderCartItems() {
    const cartItems = cart.getAllItems();

    let totalPrice = 0;
    let totalPriceAfterDiscount = 0;
    let totalDiscount = 0;

    // adding product to cart
    const cards = cartItems.reduce((prev, curr) => {
        // different product and number of quantity price changing
        totalPrice += curr.price * curr.qty;

        totalPriceAfterDiscount += curr.priceAfterDiscount * curr.qty;

        totalDiscount += totalPrice - totalPriceAfterDiscount;

        return prev + "";
    }, "");

    document.getElementById("orderSummaryItems").innerHTML = cartItems.length;
    document.getElementById("summaryItems").innerHTML = cartItems.length;

    document.getElementById("totalPrice").innerHTML = Math.floor(totalPrice); //Math.floor for to get round figure numbers to avoid decimal numbers
    document.getElementById("totalPriceAfterDiscount").innerHTML = Math.floor(
        totalPriceAfterDiscount
    );
    document.getElementById("totalDiscount").innerHTML =
        Math.floor(totalDiscount);
    document.getElementById("finalTotal").innerHTML = Math.floor(
        totalPriceAfterDiscount
    );
    document.getElementById("finalPaymentButton").innerHTML = Math.floor(
        totalPriceAfterDiscount
    );
}

renderCartItems();

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