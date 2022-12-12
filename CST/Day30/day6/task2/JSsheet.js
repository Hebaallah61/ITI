var nav = document.getElementById("nav")
nav.style.listStyle = "circle";


var img = document.getElementById("header")
img.style.textAlign = "right";

//?cloning=> copy of all atributes of node(img)
var clone = img.cloneNode(true);
clone.style.textAlign = "left";

img.parentNode.appendChild(clone);