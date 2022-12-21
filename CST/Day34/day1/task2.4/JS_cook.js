/*
 * B.4. Update your cookie.js library file to handle any possible
 *wrong call of all implemented function by firing error message.
 *e.g there should be an error message if getCookie was called
 *without passing any parameter or with more than one
 *parameter.
 */

function getCookie(cookieName) {
  //?--------------------------------**1
  if (arguments.length === 0 || arguments.length > 1) {
    alert("error");
    throw RangeError("only one parameter is accepted");
  } else {
    if (typeof cookieName !== "string") {
      alert("error");
      throw TypeError("it is not a string");
    } else {
      if (cookieName.indexOf(" ") > 0) {
        throw Error("cannot accept spaces");
      } else {
        var name = cookieName + "=";
        var cooksp = document.cookie.split(";");
        for (var i = 0; i < cooksp.length; i++) {
          var cooktemp = cooksp[i];
          while (cooktemp.charAt(0) == " ")
            cooktemp = cooktemp.substring(1, cooktemp.length);
          if (cooktemp.indexOf(name) == 0)
            return cooktemp.substring(name.length, cooktemp.length);
        }
        return null;
      }
    }
  }
}

//o Retrieves a cookie value based on a cookie name.

function setCookie(cookieName, cookieValue, expiryDate) {
  if (arguments.length < 2 || arguments.length > 3) {
    alert("error");
    throw RangeError(" parameters is not acceptable");
  } else {
    if (typeof cookieName !== "string") {
      alert("error");
      throw TypeError("it is not a string");
    } else {
      if (cookieName.indexOf(" ") > 0) {
        throw Error("cannot accept spaces");
      } else {
        if (!!expiryDate) {
          if (typeof expiryDate !== "string") {
            throw Error('it is not correct data should be like "2022-05-5"');
          } else {
            document.cookie =
              cookieName + "=" + (cookieValue || "") + expiryDate + "; path=/";
          }
        } else {
          document.cookie = cookieName + "=" + (cookieValue || "") + "; path=/";
        }
      }
    }
  }
}

//o Sets a cookie based on a cookie name, cookie value,
//and expiration date.
function deleteCookie(cookieName) {
  if (arguments.length === 0 || arguments.length > 1) {
    alert("error");
    throw RangeError("only one parameter is accepted");
  } else {
    if (typeof cookieName !== "string") {
      alert("error");
      throw TypeError("it is not a string");
    } else {
      if (cookieName.indexOf(" ") > 0) {
        throw Error("cannot accept spaces");
      } else {
        document.cookie =
          cookieName + "=;Path=/; Expires=Thu, 01 Jan 1970 00:00:03 GMT;";
      }
    }
  }
}
//o Deletes a cookie based on a cookie name.
function allCookieList() {
  if (arguments.length !== 0) {
    alert("error");
    throw RangeError("only one parameter is accepted");
  } else {
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

  if (arguments.length === 0 || arguments.length > 1) {
    alert("error");
    throw RangeError("only one parameter is accepted");
  } else {
    if (typeof cookieName !== "string") {
      alert("error");
      throw TypeError("it is not a string");
    } else {
      if (cookieName.indexOf(" ") > 0) {
        throw Error("cannot accept spaces");
      } else {
        return !getCookie(cookieName) ? false : true;
      }
    }
  }
}

//o Check whether a cookie exists or not
