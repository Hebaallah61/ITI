/*
 *B.5. Create your own custom object that has getSetGen as a
 function value, this function should generate setters and getters
 for the properties of the caller object
 This object may have a description property of string value if
 needed
 Let any other created object can use this function property to
 generate getters and setters for its own properties
 Avoid generating getters or setters for any property of function
 value
 */

var myobj = {
  id: "SD-10",
  location: "Sv",
  addr: "123 str",

  GetSetGen: function () {
    for (var defaultpropname in this) {
      if (!isFunction(this.defaultpropname)) {
        var value = defaultpropname;

        this.value = this.defaultpropname;
        add_set_get(this, defaultpropname, value);
      }
    }

    function add_set_get(obj, propertyname, value) {
      Object.defineProperty(obj, propertyname, {
        get: function () {
          console.log("getter------------");

          return obj.value;
        },
        set: function (val) {
          console.log("setter------------");
          obj.value = val;
        },
      });
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

user.age = 22;
console.log(user.age);

user.name = "hana";
console.log(user.name);
