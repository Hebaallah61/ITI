function func1() {

    var arr = [];
    var num, multi = 1, sum = 0, divid;
    for (let i = 0; i < 3; i++) {
        var inpt = parseInt(prompt("enter number " + (i + 1) + ":"));
        arr[i] = inpt;
    }

    for (i in arr) {
        sum += arr[i];
    }
    for (i in arr) {
        multi *= arr[i];
    }
    divid = arr[0] / arr[1] / arr[2];

    document.write("sum of 3 values ".fontcolor("red") + arr[0] + "+" + arr[1] + "+" + arr[2] + "=" + sum + "</br></br>" + "multi of 3 values  ".fontcolor("red") + arr[0] + "*" + arr[1] + "*" + arr[2] + "=" + multi + "</br></br>" + "division of 3 values ".fontcolor("red") + arr[0] + "/" + arr[1] + "/" + arr[2] + "=" + divid + "</br></br>");



}

func1();
