var allimages = document.querySelectorAll("img");
console.log(allimages)
var id;
var index = 0;
{
    function change() {
        id = setInterval(function () {
            if (index < allimages.length) {
                allimages[index++].src = "/img/marble3.jpg";
                allimages[index - 2].src = "/img/marble1.jpg";
            }
            else {
                allimages[index - 1].src = "/img/marble1.jpg";
                index = 0;
            }
        }, 1000)
    }
    change()
    function onmouse() {
        clearInterval(id)
    }
}