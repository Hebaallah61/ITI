/** @type
      {HTMLCanvasElement}
       */

var cac = document.getElementById("cav");
var ctx = cac.getContext("2d");
var x = cac.height / 2;

ctx.beginPath();
ctx.arc(x, x, x, 0, Math.PI * 2);
ctx.closePath();

var gr = ctx.createRadialGradient(x, x, x * 0.8, x, x, x);
gr.addColorStop(0, "#990000");
gr.addColorStop(1, "#ff8080");
ctx.fillStyle = gr;
ctx.fill();

ctx.beginPath();
ctx.arc(x, x, x * 0.6, 0, Math.PI * 2);
ctx.closePath();

var gr1 = ctx.createRadialGradient(x, x * 0.6, x * 0.8, x * 0.3, x * 0.9, x);
gr1.addColorStop(0, "#ff8080");
gr1.addColorStop(1, "#990000");
ctx.fillStyle = gr1;
ctx.fill();

ctx.fillStyle = "white";
ctx.font = "250px Arial";
ctx.fillText("H", x / 1.8, cac.height * 0.72);
