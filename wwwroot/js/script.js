// init Isotope
var $grid = $(".collection-list").isotope({
  // options
});
// filter items on button click
$(".filter-button-group").on("click", "button", function () {
  var filterValue = $(this).attr("data-filter");
  resetFilterBtns();
  $(this).addClass("active-filter-btn");
  $grid.isotope({
    filter: filterValue,
  });
});

var filterBtns = $(".filter-button-group").find("button");

function resetFilterBtns() {
  filterBtns.each(function () {
    $(this).removeClass("active-filter-btn");
  });
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