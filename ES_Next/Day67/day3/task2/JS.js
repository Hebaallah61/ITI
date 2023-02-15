/*
2) Proxy
create a dynamic object using Proxy such that it has only the 
following properties
 name property that accepts only string of 7 characters 
 address property that accepts only string value
 age property that accepts numerical value between 25 and 
60

*/

var obj = {
  name: "heba",
  address: "cairo",
  age: 23,
};

var handler = {
  set(target, prop, value) {
    if (
      target.hasOwnProperty(prop) &&
      prop == "age" &&
      typeof value === "number"
    ) {
      if (value <= 60 && value >= 25) target[prop] = value;
      else throw Error`invalid range of age`;
    } else if (
      target.hasOwnProperty(prop) &&
      prop == "address" &&
      typeof value === "string" &&
      value instanceof String
    ) {
      if (typeof value === "string") target[prop] = value;
      else throw Error`invalid type`;
    } else if (
      target.hasOwnProperty(prop) &&
      prop == "name" &&
      typeof value === "string"
    )
      if (typeof value === "string" && value.length === 7) target[prop] = value;
      else throw Error`invalid range of name`;
  },
  get(target, prop) {
    if (target.hasOwnProperty(prop)) return target[prop];
    else throw Error`invalid property`;
  },
};

var myProxy = new Proxy(obj, handler);
//myProxy.age = 66;
//myProxy.z;
//myProxy.name = "hhhhhhhhhhh";
