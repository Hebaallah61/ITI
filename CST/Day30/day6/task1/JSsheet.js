var PElement = document.getElementById('p');

for (var i of document.getElementsByTagName('input')) {
    i.addEventListener("change", (event) => {
        if (event.target.checked) {
            PElement.style[event.target.name] = event.target.value;
        }
    });
}


