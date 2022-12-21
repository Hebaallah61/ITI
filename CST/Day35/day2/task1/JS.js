/*
Using the constructor method for creating Objects, write a 
script that allows you to create a rectangle object that
• Should have width and height properties.
• Implement a method for calculating its area 
• Implement a method for calculating its perimeter.
• Implement displayInfo() function to display a message 
declaring the width, height, area, and perimeter of the 
created object
 */

function rectangle(w, h) {
  this.w = w;
  this.h = h;
  this.getperimeter = function () {
    return 2 * (this.h + this.w);
  };
  this.getarea = function () {
    return this.h * this.w;
  };

  this.displayinfo = function () {
    console.log(
      " width= {" +
        this.w +
        "} \n height= {" +
        this.h +
        "} \n perimeter= {" +
        this.getperimeter() +
        "}\n area= {" +
        this.getarea() +
        "} "
    );
  };
}

var rect = new rectangle(50, 80);
rect.getarea();
rect.getperimeter();
rect.displayinfo();
