/*Build your own function that takes a single string argument and 
returns the largest word in the string. If there are two or more words 
that are the same length, return the first word from the string with that 
length. 
e.g. if Input is: "this is a javascript string demo"
Output will be: javascript
 */

let max = 0, word = null;
let s1 = "this is a javascript string demo";
function func2(str) {
    let sp = str.split(" ");
    console.log(sp);
    for (i in sp) {
        if (sp[i].length > max) {
            max = sp[i].length;
            word = sp[i];
        }
    }
    return word;
}

func2(s1);