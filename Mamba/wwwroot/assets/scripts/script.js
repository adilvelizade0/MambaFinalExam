const nav = document.querySelector("nav");

window.addEventListener("scroll", function () {
  if (window.scrollY > 30) {
    console.log("hey");
    nav.style.boxShadow = "box-shadow: -1px 8px 5px -3px rgba(0,0,0,0.33)";
  }
});
