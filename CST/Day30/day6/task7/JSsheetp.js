
var r = window.location.search;
//document.write(r);

var urlp = new URLSearchParams(r);
var name = urlp.get('name');
var title = urlp.get('title');
var p = alert("Welcom " + title + " " + name);


var gender = urlp.get('gender');

var address = urlp.get('address');

var email = urlp.get('email');

var mobile = urlp.get('mobile');


document.write(
    "<label>Address:" + address + "</label>" +
    "<br>" +
    "<label>Gender:" + gender + "</label>" +
    "<br>" +
    "<label>Email:" + email + "</label>"
    + "<br>"
    + "<label>Mobile:" + mobile + "</label>" + "<br>"

);

var useragent = navigator.userAgent;
var browsername;
if (useragent.match(/chrome|crios|chromium/i))
    browsername = 'chrome';
else if (useragent.match(/firefox|fxios/i))
    browsername = 'firfox';
else if (useragent.match(/edg/i))
    browsername = 'edge';
else
    browsername = 'undefined it';

document.write("You Are Use:" + browsername + " " + "<span style='color:red'>------->Recommended</span> To Use Chrome");
