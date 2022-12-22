//*BOTH ARE CORRECT

//? first implementation
$(document).ready(function () {
  var tim;
  function move() {
    $("#m").animate({ left: "1000px" }, 5000);

    $("#pos").text(
      '<img src="../img/12.gif" style="left:' + $("#m").css("left") + '"/>'
    );
  }

  tim = setInterval(move, 30);
});

//? second implementation
// $(document).ready(function () {
//   setInterval(function () {
//     $("#m").animate({ left: "1000px" }, 5000);

//     $("#pos").text(
//       '<img src="../img/12.gif" style="left:' + $("#m").css("left") + '"/>'
//     );
//   }, 100);
// });
