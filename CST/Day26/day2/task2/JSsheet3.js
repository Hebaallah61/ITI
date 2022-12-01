/*Write a script that reads from the user his info; validates and 
displays it with a welcoming message in console
Use coloring format according to user’s choice. The user has to choose 
either red, green or blue color, take his choice via prompt.
*/

function func3() {
    var f = 0;
    var letters = /^[A-Za-z]+$/;
    var pphone = /^[0-9]{8}$/;
    var pmobile = /^011|012|010[0-9]{7}$/;
    var eemail = /^[A-Za-z0-9._&-]+@[a-zA-Z0-9]+[a-zA-Z0-9]+.[a-zA-Z]*$/;
    var fName = prompt("enter your name");
    do {
        if (fName.match(letters)) {
            f = 0;
        }
        else {
            f = 1;
            fName = prompt("please enter your name as a char");
        }
    } while (!fName.match(letters) && f == 1);

    var pNo = prompt("enter your phone");
    do {
        if (pNo.match(pphone)) {
            f = 0;
        }
        else {
            f = 1;
            pNo = prompt("enter your correct phone number");
        }
    } while (!pNo.match(pphone) && f == 1);

    var pMo = prompt("enter your mobile");
    do {
        if (pMo.match(pmobile)) {
            f = 0;
        }
        else {
            f = 1;
            pMo = prompt("enter your correct mobile number");
        }
    } while (!pMo.match(pmobile) && f == 1);


    var eMail = prompt("enter your email");
    do {
        if (eMail.match(eemail)) {
            f = 0;
        }
        else {
            f = 1;
            eMail = prompt("enter your correct email");
        }
    } while (!eMail.match(eemail) && f == 1);



    var color = prompt("select  red or green or blue");

    document.write(`<span style="color:${color}"> welcome dear gest </span>` + fName + "</br></br>");//span way
    document.write("<font color=" + color + ">" + "your phone " + "</font>" + pNo + "</br></br>");//font color another way
    document.write("<font color=" + color + ">" + "your mobile " + "</font>" + pMo + "</br></br>");
    document.write("<font color=" + color + ">" + " your email " + "</font>" + eMail + "</br></br>");

}


func3();


