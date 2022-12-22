$(function () {
  var i = 0;
  var img = [
    "<img width='300' height='300' src='../img/1.jpg'/>",
    "<img width='300' height='300' src='../img/2.jpg'/>",
    "<img width='300' height='300' src='../img/3.jpg'/>",
    "<img width='300' height='300' src='../img/4.jpg'/>",
    "<img width='300' height='300' src='../img/5.jpg'/>",
    "<img width='300' height='300' src='../img/6.jpg'/>",
  ];

  var next_prev = [
    "<img width='50' height='50' src='../img//left.png'/>",
    "<img width='50' height='50' src='../img/right.png'/>",
  ];

  $("#b1").click(function () {
    $("#child2,#child3,#child4,#child5").hide();
    $("#child1").show(2000).text("this is my first task 😀");
  });

  $("#b2").click(function () {
    $("#child1,#child3,#child4,#child5").hide();
    //$("#child1,#child3,#child4").replaceWith(function () {
    $("#child2").show();
    //});
    $("#n").html(next_prev[0]);
    $("#p").html(next_prev[1]);
    $("#m").html(img[0]);
    $("#p").on("click", function () {
      if (i < img.length - 1) {
        $("#m").html(img[++i]);
      }
    });

    $("#n").on("click", function () {
      if (i < img.length && i >= 1) {
        $("#m").html(img[--i]);
      }
    });
  });

  $("#b3").click(function () {
    $("#child1,#child2,#child4,#child5").hide();
    $("ul li").each(function (i, item) {
      $("#child3").append(item).slideDown(3000);
    });
  });

  $("#b4").click(function () {
    $("#child1,#child2,#child3,#child5").hide();
    $("#child4").show(2000);
  });

  $("#send").click(function () {
    $("#child1,#child2,#child3,#child4").hide();
    $("#child5").show(2000);
    var value1 = $("#comp").val();
    var value2 = $("#name").val();
    var value3 = $("#email").val();
    var value4 = $("#phone").val();
    $("#can").text(value1);
    $("#naan").text(value2);
    $("#eman").text(value3);
    $("#phan").text(value4);
  });

  $("#edit").click(function () {
    $("#child1,#child2,#child3,#child5").hide();
    $("#child4").show(2000);
  });
});
