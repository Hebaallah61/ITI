/* Create a parent a window that opens a scrollable advertising 
child window */

function openwin() {
    child_win = window.open("child.html", "", "status=1,width=250,height=150,scrollbars=yes");
    var message = 'Lorem ipsum, or lipsum as it is sometimes known, is dummy text used in laying out print, graphic or web designs. The passage is attributed to an unknown typesetter in the 15th century who is thought to have scrambled parts of Ciceros De Finibus Bonorum et Malorum for use in a type specimen book. It usually begins with Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.”The purpose of lorem ipsum is to create a natural looking block of text (sentence, paragraph, page, etc.) that doest distract from the layout. A practice not without controversy, laying out pages with meaningless filler text can be very useful when the focus is meant to be on design, not content.'
    child_win.document.write(message);
};



var index = 0, before = -1;
var tim = setInterval(function () {
    if (!child_win.closed && before != child_win.scrollY) {
        before = child_win.scrollY;
        child_win.scrollTo(0, index += 10);
    }
    else {
        stop();
    }
}, 500);


function stop() {
    if (!child_win.closed) {
        child_win.close();
    }

    clearInterval(tim);
    tim = null;

}




