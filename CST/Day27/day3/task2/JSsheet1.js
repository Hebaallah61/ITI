/*Write a script that shows a “typing message” appearing in a 
new child window. The new window should close after few seconds of 
displaying your message.
 */

var win;
function openwin() {
    child_win = window.open("child.html", "", "width=500,height=200");

}

var message = "I love you, dear sister! You were always like a friend to me who I'd share my secrets with and who was my piggy bank. Thank you sister for always being there, love you loads! In this whole wide world, there is you my dear sister, you are my go-to person whenever I need it. Love you from the bottom of my heart!";
message = message.split('');
i = 0;

var tim = setInterval(function () {
    if (i < message.length) {

        child_win.document.write(message[i++]);
    }
    else {
        stop();
    }
}, 500);


function stop() {
    child_win.closed();
}


