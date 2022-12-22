$("#mm1").draggable();

$("#mm2").droppable();

$("#mm2").on("drop", function (e) {
  $("#mm1").hide(3000);
});
