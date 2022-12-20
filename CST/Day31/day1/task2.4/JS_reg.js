function regist() {
  location.href = "My_profile.html";
  setCookie("username", document.getElementById("fname").value, "");
  setCookie("age", document.getElementById("age").value, ""); //? "age", document.getElementById("age").value, ""
  setCookie(
    "gender",
    document.querySelector('input[name="gender"]:checked').value,
    ""
  );
  setCookie("color", document.getElementById("color").value, "");
  setCookie("counter", 0, "");
}
