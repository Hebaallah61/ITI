/*
 *B.3. Create an adding function that adds n numbers only.
 *Throw exception if the user passed any data type other than
 *“number” or called your function without passing any
 *parameters.
 */

function add() {
  let sum = 0;
  if (arguments.length === 0) {
    throw RangeError("zero parameter passed is not accepted");
  } else {
    for (let i = 0; i < arguments.length; i++) {
      if (typeof arguments[i] !== "number") {
        throw TypeError("the type is not acceptable");
      } else {
        sum += arguments[i];
      }
    }
  }
  console.log(`sum=${sum}`);
}

add(1, 2, 3);

//? add();

//? add(1, 2, "me");
