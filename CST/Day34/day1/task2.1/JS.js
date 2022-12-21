/**
 *TODO B.1. Write two different functions with two different ways of implementations that takes
 *TODO any number of parameters and returns them as a reversed collection using array’s reverse function.
 *TODO Note: using of any loop is not allowed*/

function reversenumb1() {
  console.log(Array.from(arguments).reverse());
}

reversenumb1(1, 2, 3);

reversenumb1(1, 2, 3, 9, 8, 6);
//*?-------------------------
function reversenumb2() {
  console.log(Array.prototype.slice.call(arguments).reverse());
}

reversenumb2(1, 2, 3);

reversenumb2(1, 2, 3, 9, 8, 6);
//*?-------------------------
function reversenumb3() {
  console.log([].slice.call(arguments).reverse());
}

reversenumb3(1, 2, 3);

reversenumb3(1, 2, 3, 9, 8, 6);
//?--------------------------
function reversenumb4(...arg) {
  console.log(arg.reverse());
}

reversenumb4(1, 2, 3);

reversenumb4(1, 2, 3, 9, 8, 6);

function reversenumb5() {
  console.log(Array.apply(null, arguments).reverse());
}

reversenumb5(1, 2, 3);

reversenumb5(1, 2, 3, 9, 8, 6);

function reversenumb6() {
  console.log(Object.values(arguments).reverse());
}

reversenumb6(1, 2, 3);

reversenumb6(1, 2, 3, 9, 8, 6);
