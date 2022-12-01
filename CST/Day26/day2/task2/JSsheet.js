/*Write a script that accepts a string from user through prompt and 
count the number of a specific character that the user will define in 
another prompt. Ask the user whether to consider difference between 
letter cases or not then display the number of letter appearance.
*/
function func0() {
    var lettersc = /^[a-z]$/;
    var letters = /^[A-Z]$/;

    var str = prompt("enter string");
    var sspecif = prompt("enter a specifici char");
    var sens = parseInt(prompt("sensitive(1) or not(2)"));
    var count = 0;
    var strnot = str.toLowerCase();






    for (i in str) {
        if (sens == 1) {
            if (str[i] == sspecif.match(letters)) {
                count++;
            }

            else if (str[i] == sspecif.match(lettersc)) {
                count++;
            }
        }
        else if (sens == 2) {
            if (strnot[i] == sspecif.match(lettersc)) {
                count++;
            }
        }
    }
    document.write(count);
}

func0();