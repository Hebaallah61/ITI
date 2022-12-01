
function fun1() {
    var mess = prompt("enter your message", " ");
    for (i = 1; i <= 6; i++) {
        document.write('<h' + i + '>' + mess + '<h' + i + '> <br>');
    }

}
fun1();

function fun2() {
    var num, sum = 0, flag = 0;
    do {
        num = parseInt(prompt("enter number"));
        if (isFinite(num) && num !== 0) {
            sum += num;
        }

        else flag = 1;




    } while (sum < 100 && num != 0 && flag == 0);

    document.write('<h1>' + sum + '<h1> <br>');
}

fun2();


