/**
 * 1) Using ES6 new Syntax & features:
 Write a script to create different shapes (rectangle, square, 
 circle, triangle) make all of them inherits from polygon.
 Display the area and each object parameter in your console 
 by overriding toString()
 Draw your created shapes to a canvas element.
 */

class Polygon {
  constructor(height, width, _name = "Polygon") {
    this.height = height;
    this.width = width;
    this.name = _name;
  }

  getArea() {
    return this.height * this.width;
  }

  toString() {
    return `Height: ${this.height}, Width: ${this.width} Area of ${
      this.name
    }: ${this.getArea()}`;
  }
}

class Rectangle extends Polygon {
  constructor(height, width) {
    name = "rectangle";
    super(height, width, name);
  }

  draw() {
    let ctx = document.getElementById("canvas").getContext("2d");

    ctx.fillStyle = "#f00";

    ctx.fillRect(200, 200, this.width, this.height);

    console.log("Rectangle drawn Done");
  }
}

class square extends Polygon {
  constructor(height, width) {
    name = "square";
    super(height, width, name);
  }

  draw() {
    let ctx = document.getElementById("canvas").getContext("2d");

    ctx.fillStyle = "#f00";

    ctx.fillRect(400, 400, this.width, this.width);

    console.log("square drawn Done");
  }
}

class circle extends Polygon {
  constructor(height, width) {
    name = "circle";
    super(height, width, name);
  }

  draw() {
    let ctx = document.getElementById("canvas").getContext("2d");

    ctx.fillStyle = "#f00";
    ctx.beginPath();
    ctx.arc(600, 50, this.height, 0, 2 * Math.PI);
    ctx.fill();
    console.log("circle drawn Done");
  }
  getArea() {
    return Math.PI * Math.pow(this.height, 2);
  }

  toString() {
    return `circle: ${super.toString()}, Area: ${this.getArea()}`;
  }
}

class triangle extends Polygon {
  constructor(height, width) {
    name = "triangle";
    super(height, width, name);
  }

  draw() {
    let ctx = document.getElementById("canvas").getContext("2d");
    ctx.fillStyle = "#f00";
    ctx.beginPath();
    ctx.moveTo(this.height, this.height);
    ctx.lineTo(this.height, this.width);
    ctx.lineTo(this.width, this.height);
    // ctx.closePath();
    // ctx.stroke();
    ctx.fill();

    console.log("triangle drawn Done");
  }

  getArea() {
    return (this.width * this.height) / 2;
  }

  toString() {
    return `triangle: ${super.toString()}, Area: ${this.getArea()}`;
  }
}

let rect = new Rectangle(50, 80);

console.log(rect);

rect.draw();

let sq = new square(50, 50);

console.log(sq);

sq.draw();

let tr = new triangle(100, 20);

console.log(tr);

tr.draw();

let ci = new circle(50, 50);

console.log(ci);

ci.draw();
