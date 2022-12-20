/*
A.1. Make your own custom Object that simulates the linked list 
that accepts objects with a single numeric property value in 
ascending order. Let your object has the following functionalities
*• Enqueue a value as long as the value is in the sequence
otherwise through an exception (push an item at the end of 
the list with the passed value).
*• Insert an item in a specific place as long as the value is 
missing from the sequence otherwise through an exception.
*• Pop a value (remove an item from the end of the list).
*• Remove an item from a specific place with the required 
value, if the value is not added return a message with “data 
not found”.
*• Dequeue a value (remove an item from the beginning of the 
list).
• Display the content of the list.
• Ensure that there is no duplication in your entered values. 
• You can add any property you need.
Note: Use Array Object methods and there is no need to use 
sort() function.
*/

var linkedlist = {
  value: [{ val: 2 }, { val: 4 }, { val: 5 }],

  insert: function (val) {
    if (this.value.includes(val) == true)
      throw RangeError("can not insert this value");
    else {
      if (typeof val === "number") {
        this.value.push({ val });
        this.value.sort(function (a, b) {
          return a.val - b.val;
        });
        console.log(this.value);
      } else throw TypeError("this is not a number");
    }
  },

  pop: function () {
    console.log(this.value.pop()); //splice(this.value.length - 1, 1)
  },
  dequeue: function () {
    console.log(this.value.shift()); //splice(0, 1)
  },

  push: function (val) {
    if (val > this.value[this.value.length - 1].val) {
      this.value.push({ val });
      console.log(this.value);
    } else if (val === this.value[this.value.length - 1].val) {
      throw new Error("can not push this value because it is exist");
    } else {
      throw new Error("can not push this value");
    }
  },

  remove: function (val) {
    for (var i in this.value) {
      if (this.value[i].val == val) {
        this.value.splice(i, 1);
        return console.log(this.value);
      }
    }
    console.log("not found");
  },

  enqueue: function (val) {
    if (val > this.value[0].val) {
      throw new Error("can not enqueue this value");
    } else if (val === this.value[0].val) {
      throw new Error("can not enqueue this value because it is exist");
    }

    this.value.unshift({ val });
    console.log(this.value);
  },
};

linkedlist.insert(1); //1,2,4,5

linkedlist.insert(6); //1,2,4,5,6

linkedlist.insert(3); //1,2,4,5

linkedlist.pop(); //6---1,2,4,5
linkedlist.dequeue(); //1---2,4,5

linkedlist.remove(5); //5---2,4
linkedlist.remove(3); //not found

linkedlist.enqueue(1); //1,2,4

linkedlist.push(11);
linkedlist.push(11);

//linkedlist.enqueue(1); //exist
//linkedlist.enqueue(10);
