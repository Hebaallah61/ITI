



function getCookie(cookieName) {
    var name = cookieName + "=";
    var cooksp = document.cookie.split(";");
    for (var i = 0; i < cooksp.length; i++) {
        var cooktemp = cooksp[i];
        while (cooktemp.charAt(0) == ' ')
            cooktemp = cooktemp.substring(1, cooktemp.length);
        if (cooktemp.indexOf(name) == 0)
            return cooktemp.substring(name.length, cooktemp.length);

    }
    return null;
}


//o Retrieves a cookie value based on a cookie name.

function setCookie(cookieName, cookieValue, expiryDate) {
    if (!!expiryDate) {

        document.cookie = cookieName + "=" + (cookieValue || "") + expires + "; path=/";
    }
    else {
        document.cookie = cookieName + "=" + (cookieValue || "") + "; path=/";
    }


}


//o Sets a cookie based on a cookie name, cookie value,
//and expiration date.
function deleteCookie(cookieName) {
    document.cookie = cookieName + "=;Path=/; Expires=Thu, 01 Jan 1970 00:00:03 GMT;";
}
//o Deletes a cookie based on a cookie name.
function allCookieList() {
    var decodcook = decodeURIComponent(document.cookie).trim();
    var cooksp = decodcook.split(";");
    var arr = [];
    for (var i in cooksp) {
        var cook = cooksp[i].trim().split("=");
        var k = cook[0];
        var v = cook[1];
        arr[k] = v;
    }
    return arr;
}
//o returns a list of all stored cookies
function hasCookie(cookieName) {
    /* var cooksp = document.cookie.split(";");
     for (var cook of cooksp) {
         cook = cook.split("=");
         if (cook[0].trim() === cookieName)
             return true;
     }
     return false;*/

    return (!getCookie(cookieName)) ? false : true;
}
//o Check whether a cookie exists or not

