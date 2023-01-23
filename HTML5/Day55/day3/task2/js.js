var cav = document.getElementById("cav");
var ctx = cav.getContext("2d");
function lineanimation() {
  var x = 0;
  var y = 0;
  ctx.moveTo(x, y);
  var intervalID = setInterval(function () {
    x += 10;
    y += 10;
    ctx.lineTo(x, y);
    ctx.stroke();
    if (x >= 300 && y >= 300) {
      clearInterval(intervalID);
      setTimeout(function () {
        alert("animation ended");
      }, 500);
    }
  }, 100);
}
lineanimation();
