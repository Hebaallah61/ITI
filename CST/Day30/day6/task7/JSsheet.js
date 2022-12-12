

var tim = new Event("timeout");
document.addEventListener("timeout", function () {
    var timout;
    document.onmousemove = function () {
        clearInterval(timout);
        timout = setTimeout(function () {
            alert("move the mouse");
        }, 5000);
    }
})

document.dispatchEvent(tim);


var button = document.getElementById("sub");
button.addEventListener("click", (event) => {
    var x = confirm("continue?");
    if (x === true) {
        document.getElementById("formmy").action = "welcom.html"

    }
    else {
        event.preventDefault();
    }

})

