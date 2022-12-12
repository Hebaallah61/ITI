
var normalMove = 10, reverseMove = 450, step = 10, tim, i = 0, flag = 0;

var lefticon = document.getElementById("f");
var righticon = document.getElementById("s");
var bottomicon = document.getElementById("t");

var startmove = document.getElementById("start");

startmove.addEventListener("click", function () {

    if (startmove.innerText == "Move") {
        flag = 1;
        move();
        startmove.innerText = "Stop";
    } else {
        flag = 0;
        clearTimeout(tim);
        console.log("2")
        startmove.innerText = "Move";
    }
});

icon1Info = document.getElementById('icon1Style');
icon2Info = document.getElementById('icon2Style');


function move() {

    if (flag) {
        lefticon.style.left = (normalMove + "px");
        righticon.style.left = (reverseMove + "px");
        bottomicon.style.top = (reverseMove + "px");
        normalMove += step;
        reverseMove += -step;

        i += 10;
        if (i == 450) {
            step *= -1;
            i = 0;
        }


        icon1Info.innerText = Number(lefticon.getBoundingClientRect().x).toFixed(0);
        icon2Info.innerText = Number(righticon.getBoundingClientRect().x).toFixed(0);


        tim = setTimeout(move, 30);
    }

}

function reset() {

    normalMove = 10;
    reverseMove = 450;
    step = 10;
    i = 0;
    startmove.innerText = "Move";

    lefticon.style.left = "0%";
    righticon.style.right = "0%";
    bottomicon.style.bottom = "0%";


}

