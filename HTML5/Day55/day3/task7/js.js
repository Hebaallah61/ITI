/** @type
          {HTMLCanvasElement}
           */

var cac = document.getElementById("cav");
var ctx = cac.getContext("2d");
function draw() {
  ctx.fillStyle = "rgb(0, 38, 77,0.6)";
  ctx.beginPath();
  ctx.moveTo(200, 200);
  ctx.lineTo(200, 45);
  ctx.lineTo(45, 200);
  ctx.fill();
  ctx.closePath();
  ctx.stroke();
  ctx.fillStyle = "black";
  ctx.font = "30px Arial";
  ctx.fillText("a", 100, 100);
  ctx.fillText("b", 120, 230);
  ctx.fillText("c", 220, 150);
}
draw();
