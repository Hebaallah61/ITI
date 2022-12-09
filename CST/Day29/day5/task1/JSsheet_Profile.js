function changname() {
    document.getElementById("pname").innerHTML = getCookie("username");
    document.getElementById("pname").style = "color:" + getCookie("color");
    document.getElementById("counter").style = "color:" + getCookie("color");



}


function imgch() {
    /*if (document.cookie = "gender".value === "male") {
        document.getElementById("img").src = "./img/1.jpg";
    }
    else {
        document.getElementById("img").src = "./img/2.jpg";
    }*/

    var g = document.getElementById("img");
    console.log(getCookie("gender"));
    var src = getCookie("gender") === "male" ? "./img/1.jpg" : "./img/2.jpg";

    g.src = src;
}

function count() {
    var i = Number(getCookie("counter"));
    // i++;
    document.cookie = "counter=" + (i + 1);
    console.log(i);
    // return i;
}

function updatecount() {
    //count();
    var message = getCookie("counter") + "times";
    document.getElementById("counter").innerHTML = message;
}

function chang() {
    changname();
    count();
    updatecount();
    imgch()
}