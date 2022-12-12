window.addEventListener('keydown', function (event) {
    if (event.key.length == 1)
        alert("Ascii code of " + event.key + " is " + event.key.charCodeAt(0));
    else
        alert("you pressed " + event.key);
});