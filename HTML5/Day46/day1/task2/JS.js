var red = document.getElementById("color1");
var green = document.getElementById("color2");
var blue = document.getElementById("color3");
var p = document.getElementById("parag");

red.onchange = function () {
  p.style.color =
    "rgba(" + red.value + "," + green.value + "," + blue.value + ")";
};
green.onchange = function () {
  p.style.color =
    "rgba(" + red.value + "," + green.value + "," + blue.value + ")";
};
blue.onchange = function () {
  p.style.color =
    "rgba(" + red.value + "," + green.value + "," + blue.value + ")";
};
