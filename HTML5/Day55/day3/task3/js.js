/** @type
      {HTMLCanvasElement}
       */
var cac = document.getElementById("cav");
var ctx = cac.getContext("2d");

function stad() {
  var grad1 = ctx.createLinearGradient(0, 0, 0, cac.height / 2);
  grad1.addColorStop(0, "#66ccff");
  grad1.addColorStop(1, "white");
  ctx.fillStyle = grad1;
  ctx.fillRect(0, 0, cac.width, cac.height / 2);
  grad1 = ctx.createLinearGradient(0, cac.height / 2, 0, cac.height);
  grad1.addColorStop(0, "#33cc33");
  grad1.addColorStop(1, "#33cc32");
  ctx.fillStyle = grad1;
  ctx.fillRect(0, cac.height / 2, cac.width, cac.height);
  var grad1 = ctx.createLinearGradient(0, cac.height, 0, cac.height / 2);
  grad1.addColorStop(0, "black");
  ctx.strokeStyle = grad1;
  ctx.strokeRect(cac.width / 4, cac.height / 4, cac.width / 2, cac.height / 4);
}

var x = cac.width / 2;
var y = cac.height / 2 + 150;

//   function drawBall() {
//     ctx.beginPath();
//     ctx.arc(x, y, 20, 0, Math.PI * 2);
//     ctx.fillStyle = "red";
//     ctx.fill();
//     ctx.closePath();

//     // x -= 0;
//     // y -= 5;
//     // setTimeout(drawBall, 16);
//   }

function moveBall() {
  ctx.clearRect(0, 0, cac.width, cac.height);

  ctx.beginPath();

  var x = Math.random() * (cac.width - 60) + 30;

  var y = Math.random() * (cac.height - 60) + 30;
  stad();

  ctx.arc(x, y, 20, 0, Math.PI * 2);

  ctx.fillStyle = "red";

  ctx.fill();

  ctx.closePath();
}
setInterval(moveBall, 500);
