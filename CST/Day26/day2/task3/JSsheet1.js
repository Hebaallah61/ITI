
var arr2 = [];
function func2() {

    for (let i = 0; i < 5; i++) {
        var inpt = parseInt(prompt("enter number " + (i + 1) + ":"));
        arr2[i] = inpt;
    }

    document.write("Entered values are:".fontcolor("red") + arr2.toString() + "</br></br>");

    document.write("array sorted ascending: ".fontcolor("red") + arr2.sort(function (a, b) { return a - b; }) + "</br></br>");

    document.write("array sorted descending: ".fontcolor("red") + arr2.sort(function (a, b) { return b - a; }) + "</br></br>");





}

func2();