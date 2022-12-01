function fun1() {
    var rad = parseInt(prompt("Enter the value of a circle’s radius", "type radius here"));
    var area = Math.PI * rad * rad;
    window.alert("the area of cicle is:" + area);


    var num = parseInt(prompt("Enter the value to know square root", "type value here"));
    var sqrr = Math.sqrt(num);
    window.alert("the square root of number is:" + sqrr);


    var ang = parseInt(prompt("Enter an angle to calculate its cos value", "type value here"));
    var rad = ang * (Math.PI / 180);
    var co = Math.cos(rad);

    //window.alert("the square root of number is:" + co);
    // document.write("cos " + ang + "°" + " is " + Math.cos(ang * (Math.PI / 180)).toFixed(4));
    document.write("cos " + ang + "°" + " is " + co.toFixed(4));


}

fun1();
