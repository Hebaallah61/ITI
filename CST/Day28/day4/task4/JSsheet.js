var result = document.getElementById("result");
function clearScreen() {
    document.getElementById("result").value = "";
}


function display(num) {
    document.getElementById("result").value += num;
}




/*function calculate() {
    var x = document.getElementById("result").value;
    var y = eval(x);
    document.getElementById("result").value = y;


}*/


var x, y, operator;
function calculate() {

    y = result.value;
    result.value = "";
    if (operator === "+")
        result.value = parseFloat(x) + parseFloat(y)
    if (operator === "-")
        result.value = parseFloat(x) - parseFloat(y)
    if (operator === "*")
        result.value = parseFloat(x) * parseFloat(y)
    if (operator === "/")
        result.value = parseFloat(x) / parseFloat(y)
    if (operator === "+")
        result.value = parseFloat(x) + parseFloat(y)


}

function operator(op) {
    x = result.value;
    result.value = "";
    operator = op;
}


