/*
 *B.2. Create a function that accepts only 2 parameters and throw
 *exception if number of parameters either less than or exceeds 2
 *parameters
 */

function isaccepted(p1, p2) {
  if (arguments.length === 2) console.log("accepted");
  else throw RangeError("the parameters are more than two");
}

isaccepted(1, 2);

isaccepted(1, 2, 3, 4);
