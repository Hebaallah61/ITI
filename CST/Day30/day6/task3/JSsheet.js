



function generatecard() {
    var mess = document.getElementById("tx").value;
    var img = document.querySelector('input[name="card"]:checked').value;
    var card = window.open("./generatedcard.html", "_blank", "height=600 , width=500");

    card.addEventListener('DOMContentLoaded', () => {

        //change(img, mess, card);

        var selectedimg = document.createElement("img");
        selectedimg.src = "./img/" + img + ".jpg";
        selectedimg.style.width = "500px";
        selectedimg.style.height = "500px";

        var paragraph = document.createElement("p");
        paragraph.innerText = mess;
        paragraph.style = "text-align:center";

        var button = document.createElement("button");
        button.innerText = "Close";
        button.style.marginLeft = "45%";
        button.onclick = () => { card.close(); }
        card.document.body.appendChild(selectedimg);
        card.document.body.appendChild(paragraph);
        card.document.body.appendChild(button);

    });
}
