var cav = document.querySelector("#cav");
var ctx = cav.getContext("2d");
console.log(cav);
var img = new Image();
img.src = "./1.1.jpg";
img.onload = function () {
  ctx.drawImage(img, 0, 0);
  ctx.lineWidth = 1;
  ctx.fillStyle = "#ff6666";
  ctx.strokeStyle = "#ff9900";
  ctx.font = "bold 28pt sans-serif";
  ctx.shadowOffsetX = -2;
  ctx.shadowOffsetY = 2;
  ctx.shadowColor = "#ffff66";
  ctx.fillText("welcome to the dark", 1, 480);
};
