/*Write a script to determine whether the entered string is 
palindrome or not. Request the string to be entered via prompt, ask the 
user whether to consider case sensitivity of the entered string or not via 
confirm, handle both cases in your script
i.e. RADAR NOON MOOM are palindrome.
Note: raDaR is not a palindrome if user requested considering case of 
entered string, it will be palindrome if user requested ignoring case 
sensitivity */

function func1() {
    var str = prompt("enter string");
    var ask = confirm("sensitive(ok) or not(cancle)");
    var sspl = str.split('');
    var srev = sspl.reverse();
    var strrev = srev.join('');

    if (ask == true) {
        if (str == strrev)
            document.write("palindrome");

        else
            document.write("not a palindrome");
    }

    else {
        str = str.toLowerCase();
        strrev = strrev.toLowerCase();
        if (str == strrev)
            document.write("palindrome");

        else
            document.write("not a palindrome");

    }

}

func1();


