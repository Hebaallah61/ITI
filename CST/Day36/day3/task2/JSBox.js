/**
 *  TODO  Create your box object that contains books objects
 *  TODO  Box object has the following properties: height, width, length, material, content. The content property contains an array books
 *  TODO  Implement .valueof() so that if there is more than one box object we can get total number of books in these boxes by adding them
    //?i.e. if box1 has 5 books and box2 has 2 books,then box1 + box2 should return 7
 */

function box(height, width, length, material, content) {
  if (arguments.length != 5) throw Error("invalid number of arguments");
  if (
    typeof height !== "number" ||
    typeof width !== "number" ||
    typeof length !== "number" ||
    typeof material !== "string"
  ) {
    throw Error("invalid type of arguments");
  }

  Object.defineProperties(this, {
    height: { value: height },
    width: { value: width },
    length: { value: length },
    material: { value: material },
    content: { value: content },
    count: {
      count: {
        value: content.length,
      },
    },
  });

  Object.defineProperty(this, "countbooks", {
    value: function () {
      return this.content.length;
    },
  });

  //*methods
  Object.defineProperty(this, "addbook", {
    value: function (book1) {
      if (book1 instanceof book) {
        this.content.push(book1);
        //this.count = this.count.length; //??
      } else throw Error("invalid type");
    },
  });

  Object.defineProperty(this, "deletebook", {
    value: function (titlex) {
      if (typeof titlex !== "string") {
        throw Error("invalid type");
      } else {
        for (var i = 0; i < this.content.length; i++) {
          console.log(this.content[i].title);
          if (titlex == this.content[i].title) {
            var temp = content[i];
            if (this.content[i].numofCopies > 1) {
              this.content[i].numofCopies--;
            } else {
              console.log(this.content.splice(i, 1));
            }
            temp.numofCopies--;
            return temp;
          }
          console.log("k");
        }
      }
    },
  });

  box.prototype.valueOf = function () {
    return this.content.length;
  };

  // Object.seal(this);
}

box.prototype.toString = function () {
  console.log(
    "width:{" +
      this.width +
      "} height: {" +
      this.height +
      "} numbers of books:{" +
      this.content.length +
      "}"
  );
};

//----------------------------------------------

var box1 = new box(5, 5, 5, "G", []);
var box2 = new box(10, 10, 5, "w", []);

var book1 = new book("b1", 10, "a1", 50, "k", 1);
var book2 = new book("b2", 3, "a2", 50, " k", 3);
var book3 = new book("b3", 9, "a3", 300, "k", 4);

box1.addbook(book1);
box1.addbook(book2);
box2.addbook(book3);

box1.deletebook("b1");
box1.toString();
box2.toString();
console.log("number of books in box1 :", box1.countbooks());
console.log("the value of two boxes : ", box1 + box2);
console.log("books obj:", book.bookcounter());

//* ---------------------------------------------------------------------------------------------------------------------------------------------------- */
// this.height = height;
// this.width = width;
// this.material = material;
// this.length = length;
// this.content = content;

// //*setter of properities
// this.setheight = function (height) {
//   this.height = height;
// };

// this.setwidth = function (width) {
//   this.width = width;
// };

// this.setmaterial = function (material) {
//   if (typeof material !== "string") {
//     throw Error("invalid type");
//   } else {
//     this.material = material;
//   }
// };

// this.setlength = function (length) {
//   this.length = length;
// };

// this.setcontent = function (content) {
//   this.content = content;
// };
// //*getters of properities

// this.getheight = function () {
//   return this.height;
// };

// this.getwidth = function () {
//   return this.width;
// };

// this.getmaterial = function () {
//   return this.material;
// };

// this.getlength = function () {
//   this.countforlength();
//   return this.length;
// };

// this.getcontent = function () {
//   return this.content;
// };

// this.addbook = function (book1) {
//   if (book1 instanceof book) {
//     this.content.push(book);
//     //this.count = this.count.length; //??
//   } else throw Error("invalid type");
// };

// this.deletebook = function (title) {
//   if (typeof title !== "string") {
//     throw Error("invalid type");
//   } else {
//     for (var i = 0; i < this.content.length; i++) {
//       if (this.content[i].title == title) {
//         var temp = content[i];
//         if (this.content[i].numofCopies > 1) {
//           this.content[i].numofCopies--;
//         } else {
//           this.content[i].pop();
//         }
//         temp.numofCopies--;
//         return temp;
//       }
//     }
//   }
// };
