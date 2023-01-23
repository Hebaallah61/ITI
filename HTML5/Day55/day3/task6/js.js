/** @type
      {HTMLCanvasElement}
       */

var canvas = document.getElementById("cav");
var ctx = canvas.getContext("2d");

//2 Halfs Circle
function drawHalfCircle() {
  ctx.beginPath();
  ctx.arc(canvas.width / 2, canvas.height / 2, 70, 0, Math.PI);
  ctx.fillStyle = "yellow";
  ctx.fill();
  ctx.stroke();
}
function drawHalfCircle1() {
  ctx.beginPath();
  ctx.arc(canvas.width / 2, canvas.height / 2, 70, 0, Math.PI, true);
  ctx.fillStyle = "yellow";
  ctx.fill();
  ctx.stroke();
}

// Full Circle
function drawFullCircle() {
  var canvas = document.getElementById("cav");
  var ctx = canvas.getContext("2d");
  ctx.beginPath();
  ctx.arc(canvas.width / 2, canvas.height / 2, 70, 0, 2 * Math.PI);
  ctx.fillStyle = "yellow";
  ctx.fill();
  ctx.stroke();
}

var flipCounter = 0;

function flipCircle() {
  if (flipCounter === 10) {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    clearInterval(tim);
    drawFullCircle();
  } else {
    setTimeout(drawHalfCircle, 200);
    setTimeout(function () {
      ctx.clearRect(0, 0, canvas.width, canvas.height);
    }, 300);

    setTimeout(drawHalfCircle1, 300);
    setTimeout(function () {
      ctx.clearRect(0, 0, canvas.width, canvas.height);
    }, 400);
    flipCounter++;
  }
}

var tim = setInterval(flipCircle, 1100);
