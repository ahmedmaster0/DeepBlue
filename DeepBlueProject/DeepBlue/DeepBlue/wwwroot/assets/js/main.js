"use strict";

// add class active -----------
let navlinks = document.querySelectorAll(".header .list li a");

navlinks.forEach((item) => {
  item.addEventListener(`click`, () => {
    document.querySelector(".header .list li a.active").classList.remove("active");
    item.classList.add("active");
  });
});

// start scroll-up ------------
let scroll = document.querySelector(".scroll-up");
window.addEventListener(`scroll`, () => {
  if (this.scrollY >= 200) {
    scroll.classList.add("show-up");
  } else {
    scroll.classList.remove("show-up");
  }
});

$(`document`).ready(() => {
  // clients
  $(".db-story .owl-carousel").owlCarousel({
    loop: true,
    autoplay: true,
    autoplayTimeout: 5000,
    dots: true,
    items: 1,
  });
});
