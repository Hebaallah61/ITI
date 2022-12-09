/*Create a parent window that opens a flying child window. Hint: 
Start by creating a parent window that opens a child window. 
Child window should always be on top view and moves up and down 
within boundaries of user screen.
Parent window should contain a button that stops child window 
movement. */

var x, y, w, h, d;
var tim;
var size = [window.width, window.height];
var child_win = window.open("child.html", "", "height=200,width=200,rezize=fixed");

x = y = d = 0;

tim = setInterval(function () {
    w = window.innerWidth;
    h = window.innerHeight;
    var s = (h - child_win.innerHeight) / (w - child_win.innerWidth);


    if (d == 0) {
        resize();
        child_win.moveTo(x += 5, y = s * x);
        child_win.focus();
        if ((x + child_win.innerWidth) >= w) {
            d = 1;
        }
    }
    else {
        resize();
        child_win.moveTo(x -= 5, y = s * x);
        child_win.focus();
        if (x <= 0) {
            d = 0;
        }
    }

}, 50);


function stop() {
    clearInterval(tim);
    child_win.focus();

}

function close() {

    child_win.close();


}

function resize() {
    child_win.resizeTo(200, 200);
    child_win.focus();
}