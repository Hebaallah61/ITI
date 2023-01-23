/** @type
      {HTMLCanvasElement}
       */

var cac = document.getElementById("cav");
var ctx = cac.getContext("2d");
var angle = 0;
ctx.fillStyle = "rgba(153, 204, 255, 0.6)";
function move() {
  ctx.clearRect(0, 0, cac.width, cac.height);
  var tim = setInterval(function () {
    drawrect();
    angle += 70;
    if (angle > 450) {
      clearInterval(tim);
      reversemove();
    }
  }, 100);
}

function reversemove() {
  ctx.clearRect(0, 0, cac.width, cac.height);
  var tim = setInterval(function () {
    drawrect();
    angle -= 70;
    if (angle < 0) {
      clearInterval(tim);
      move();
    }
  }, 100);
}
move();
function drawrect() {
  ctx.save();
  ctx.beginPath();
  ctx.translate(cac.width / 2, cac.height / 2);
  ctx.rotate(angle);
  ctx.rect(10, 10, 50, 140);
  angle += Math.PI / 180;
  ctx.fill();
  ctx.restore();
}
