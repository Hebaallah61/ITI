var myobj = {
  id: "SD-10",
  location: "Sv",
  addr: "123 str",

  GetSetGen: function () {
    var propname = Object.keys(this);
    for (var defaultpropname in propname) {
      if (!isFunction(this.defaultpropname)) {
        this["set" + propname[defaultpropname]] = (function (defaultpropname) {
          console.log("setter-------");
          return function (value) {
            this[propname[defaultpropname]] = value;
          };
        })(defaultpropname);

        this["get" + propname[defaultpropname]] = (function (defaultpropname) {
          console.log("getter-------");
          return function () {
            return this[propname[defaultpropname]];
          };
        })(defaultpropname);
      }
    }
  },
};

//***------------ */
function isFunction(val) {
  return val && {}.toString.call(val) === "[object Function]";
}

var user = {
  name: "heba",
  age: 22,
  id: "5sd",
};

myobj.GetSetGen.call(user);

user.id = "5sd22";

console.log(user.id);

user.age = 23;
console.log(user.age);

user.name = "hana";
console.log(user.name);
