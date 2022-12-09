

var i = 0;
var temp = "";
var tim;
var img = ["img/1.jpg", "img/2.jpg", "img/3.jpg", "img/4.jpg"];
function init() {
    document.getElementById('n').onclick = function () {
        //tim = setInterval(function () {
        if (i < img.length - 1) {

            temp = '<img  width="300" height="300" src=' + img[++i] + '>';
            document.getElementById('im').innerHTML = temp;


        }
        else {
            stop();
        }
    };


    function stop() {
        child_win.closed();
    }


    //------------------------------------
    document.getElementById('s').onclick = function () {
        clearInterval(tim);
    }
    //------------------------------------

    document.getElementById('ss').onclick = function () {
        tim = setInterval(function () {
            if (i < img.length) {

                temp = '<img  width="300" height="300" src=' + img[i] + '>';
                document.getElementById('im').innerHTML = temp;
                i++;

            }
            else {
                i = 0;
            }
        }, 2000);



    }


    //-----------------------------------------

    document.getElementById('p').onclick = function () {

        if (i < img.length && i >= 1) {

            temp = '<img  width="300" height="300" src=' + img[--i] + '>';
            document.getElementById('im').innerHTML = temp;


        }
        else {
            stop();
        }
    };



}

//--------------------------------------------------------------------
