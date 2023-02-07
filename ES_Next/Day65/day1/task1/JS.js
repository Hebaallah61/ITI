//?1) Swap the values of x and y using destructuring
let a = 7,
  b = 5;
console.log(`before detructuring: a=${a}  b=${b}`);
[a, b] = [b, a];
console.log(`after detructuring:  a=${a}  b=${b}`);

//?2) Using rest parameter and spread operator return min and max
//?value from any array passed to function call and display each of
//?them separately after function call
//?note: array length is not fixed

let arr1 = [1, 2, 4, 5, 10];
let arr2 = [10, 13, 50];

function min_max1(...param) {
  return { min: Math.min(...param), max: Math.max(...param) };
}

console.log(min_max1(...arr1));
console.log(min_max1(...arr2));

function min_max2(a, b, c, ...param) {
  let ar = [];
  ar[0] = Math.min(a, b, c, Number(param));
  ar[1] = Math.max(a, b, c, Number(param));
  return ar;
}

console.log(min_max2(45, 20, 30, 40)); //20,40
console.log(min_max2(1, 5, 3, Number(...arr2)));

/**
 *! TO DO 3) Study new array api methods then create the following methods and apply it on this array
 */
var fruits = ["apple", "strawberry", "banana", "orange", "mango"];

//?a. test that every element in the given array is a string
console.log(fruits.every((item) => typeof item == "string"));

//?b.test that some of array elements starts with "a"
console.log(fruits.some((item) => item.startsWith("a")));

//?c. generate new array filtered from the given array with only elements that starts with "b" or "s"
var newarray = fruits.filter(
  (item) => item.startsWith("b") || item.startsWith("s")
);
console.log(newarray);

//?d.generate new array, each element of the new array contains a string declaring that you like the give fruit element
var newarray_ = newarray.map((i) => "I Like " + i);

//?e.use forEach to display all elements of the new array from previouse poin
newarray_.forEach((item) => {
  console.log(item);
});
