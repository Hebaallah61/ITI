$(function () {
  var bands;
  $.ajax({
    method: "GET",
    url: "../Data/rockbands.json",

    success: function (result) {
      bands = result;
      $("#bands").append("<option>select band</option>");
      $.each(result, function (key, val) {
        //   console.log(key);
        $("#bands").append("<option value=" + key + ">" + key + "</option>");
      });
    },
  });

  $(document).on("change", "#bands", function (e) {
    //console.log(this.options[e.target.selectedIndex].text);
    var option = bands[e.target.value]; //all artists with names ,links in band
    //console.log(option);
    $("#artist").append("<option>select..</option>");
    $.each(option, function (key, val) {
      $("#artist").append(
        "<option value=" + val.name + ">" + val.name + "</option>"
      );
    });
  });

  $("#artist").change(function (e) {
    //console.log(bands[$("#bands").val()][e.target.selectedIndex].value);
    window.location.assign(
      //?bands[$("#bands").val()] all names and linkes of artist in band
      //?bands[e.target.selectedIndex] the name and link of selected artist
      bands[$("#bands").val()][e.target.selectedIndex].value //?only the link
    );
  });
});
