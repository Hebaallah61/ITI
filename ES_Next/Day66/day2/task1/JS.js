/**
 * 1) Create your own function that accepts multiple parameters to 
generate course information and display it. Assume that the
function accepts course information as object that contains 
courseName, courseDuation, courseOwner.
if any of required field is not set in function call it should have 
default values as follows: courseName=”ES6”
,
courseDuration=”3days”, courseOwner=”JavaScript”.
Bonus: through exception if passed object includes properties 
other than those described above
Note: user is allowed not to pass all of these properties, he can 
pass needed properties only
*/
function myfun(param) {
  var obj = {
    courseName: "ES6",
    courseDuation: "3days",
    courseOwner: "JavaScript",
  };
  var r = Object.assign({}, obj, param);
  if (Object.keys(r).length > 3) {
    throw new Error("not valid number of proberitie");
  } else {
    return `courseName:${r.courseName}  courseDuation:${r.courseDuation} courseOwner:${r.courseOwner} `;
  }
}

var obj1 = {
  courseName: "c#",
  courseDuation: "10days",
  courseOwner: ".net",
};

var obj2 = {
  courseName: "c#",
  courseDuation: "10days",
};

var obj3 = {
  courseName: "c#",
  courseDuation: "10days",
  courseOwner: ".net",
  cach: "hello",
};

var obj4 = {};

console.log(myfun(obj1));
console.log(myfun(obj2));
//console.log(myfun(obj3));
console.log(myfun(obj4));

/*
2) Create a generator that returns fibonacci series that takes only 
one parameter. Make two different implementations as 
described below:
a.the parameter passed determines the number of elements 
displayed from the series.
b.the parameter passed determines the max number of the 
displayed series should not exceed its value.

*/
function fib(param) {
  let arr = [0, 1];
  for (let i = 2; i < param; i++) {
    arr[i] = arr[i - 1] + arr[i - 2];
  }
  return arr;
}
console.log(fib(20));

function* fib1(param) {
  var p = 0,
    c = 1,
    i = 0,
    temp;
  yield p;
  i++;
  if (c < param) {
    yield c;
  } else {
    yield undefined;
  }
  if (c < param) {
    for (let n = c; n < param - 1; n++) {
      i++;
      temp = c;
      c += p;
      p = temp;
      yield c;
    }
  } else {
    yield undefined;
  }
}

var i = fib1(6);
console.log(i.next());
console.log(i.next());
console.log(i.next());
console.log(i.next());
console.log(i.next());
console.log(i.next());

function fibm(param) {
  let arr = [0, 1];
  for (let i = 2; i < 200; i++) {
    arr[i] = arr[i - 1] + arr[i - 2];
    if (arr[i] == param) {
      break;
    }
  }
  return arr;
}
console.log(fib(199));

function* fib2(m) {
  var p = 0,
    c = 1,
    i = 0,
    temp;
  yield p;
  i++;
  if (c < m) {
    yield c;
  } else {
    yield undefined;
  }
  if (c < m) {
    while (c < m) {
      temp = c;
      c += p;
      p = temp;
      yield c;
    }
  } else {
    yield undefined;
  }
}

var i = fib2(6);
console.log(i.next());
console.log(i.next());
console.log(i.next());
console.log(i.next());
console.log(i.next());
console.log(i.next());

/*
3) create your own object that has [Symbol.replace] method so
that if any long string (e.g. its length exceed 15 characters )called 
replace and pass your object as replace method parameter it will 
display only 15 character of string with terminating “…”
*/

var obj = {
  [Symbol.replace]: function (t) {
    if (t.length > 15) {
      return `${t.substring(0, 15)}///`;
    } else {
      return t;
    }
  },
};
var t1 = "meee";
t1.substring;
console.log(t1.replace(obj));
console.log("meee her ccccc jjjjjjjjjjjjjjjjjjjjj".replace(obj));
/*
4) Create an iterable object by implementing @@iterator method
i.e. Symbol.iterator, so that you can use for..of and retrieve its 
properties.
Bonus: make proper updates to retrieve the object’s properties 
and its values.
 */

var obj = {
  name: "noha",
  id: 15,
  add: "cairo",
  cv: "A",
  p1: 1,
  p2: 2,
  p3: 3,
  p4: 4,
  iterate: function* () {
    var key = Object.keys(this);
    for (let item of key) {
      if (item != "iterate") {
        yield `key:${item}  value ${this[item]}`;
      }
    }
  },
};

var t = obj.iterate();
console.log(t.next());
console.log(t.next());
console.log(t.next());
console.log(t.next());
console.log(t.next());
console.log(t.next());
console.log(t.next());
console.log(t.next());

for (let item of obj.iterate()) {
  console.log(item);
}
