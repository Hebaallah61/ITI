/**
 * TODO object that contains a list of numerical sequence, with the following details
 * TODO Your constructor takes 3 parameters to define start, end of list and step
 */

//?ctor func
//? array [1,2,3,4,5,6] stat =1 end =6 step =1
//?getters and setters for array or properities (accessor - descriptors)
//?append-prepend-dequeue from start-pop from end
//?array should be squential array or throw error
function mylist(start, end, step) {
  if (arguments.length !== 3) throw Error("invalid arguments");
  else {
    Object.defineProperty(this, "start", {
      value: start,
      enumerable: false,
      writable: false,
      configurable: false,
    });
    Object.defineProperty(this, "step", {
      value: step,
      enumerable: false,
      writable: false,
      configurable: false,
    });
    Object.defineProperty(this, "end", {
      value: end,
      enumerable: false,
      writable: false,
      configurable: false,
    });

    var mylistprop = [];
    //?1

    var fill = function () {
      for (var i = this.start; i <= this.end; i += this.step) {
        mylistprop.push(i);
      }
    }.bind(this);
    fill();
    //?

    this.append = function (element) {
      if (typeof element !== "number")
        throw Error("only numeric element is accepted");
      else if (
        mylistprop.length != 0 &&
        element - mylistprop[mylistprop.length - 1] !== step
      )
        throw Error("invalid element for this sequence");
      else mylistprop.push(element);
    };

    this.prepend = function (element) {
      if (typeof element !== "number")
        throw Error("only numeric element is accepted");
      else if (mylistprop.length != 0 && mylistprop[0] - element !== step)
        throw Error("invalid element for this sequence");
      else mylistprop.unshift(element);
    };

    this.dequeue = function () {
      return mylistprop.shift();
    };

    this.pop = function () {
      return mylistprop.pop();
    };

    this.display = function () {
      return mylistprop;
    };
  }
}

mylist.prototype.toString = function () {
  console.log(this.display());
};

var l = new mylist(1, 6, 1);
l.toString();
l.append(7);
l.toString();
l.prepend(0);
l.toString();
l.pop();
l.toString();
l.dequeue();
l.toString();
//l.append(5); //*error
//l.prepend(3);//*error

////---------------------------------
//console.log(this.mylistprop);

// this.getlist = function () {
//   return this.list;
// };
// this.setlist = function (new_List) {
//   for (var i = 0; i < new_List.length; i++) {
//     if (typeof new_List[i] !== "number")
//       throw Error("only numerical list is accepted");
//   }
//   this.step = new_List.length > 1 ? new_List[1] - new_List[0] : 1;

//   for (var i = 0; i < new_List.length - 1; i++) {
//     if (new_List[i + 1] - new_List[i] !== this.step)
//       throw Error("invalid sequence");
//   }
//   this.list = new_List;
// };
