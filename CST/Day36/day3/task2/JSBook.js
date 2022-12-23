/**
 * TODO  Book object has the following properties: title, numofChapters, author, numofPages, publisher, numofCopies
 * TODO Create book object and add it to box object content property
 * TODO Count # of books inside box
 * TODO Delete any of these books in box according to book title.(delete a single copy of the books)
 *
 */

function book(
  title,
  numofChapters,
  author,
  numofPages,
  publisher,
  numofCopies
) {
  if (arguments.length !== 6) throw Error("invalid arguments");
  if (
    typeof title !== "string" ||
    typeof numofChapters !== "number" ||
    typeof author !== "string" ||
    typeof numofPages !== "number" ||
    typeof publisher !== "string" ||
    typeof numofCopies !== "number"
  ) {
    throw Error("invalid type of arguments");
  }
  Object.defineProperties(this, {
    title: { value: title },
    numOfChapters: { value: numofChapters },
    author: { value: author },
    numOfPages: { value: numofPages },
    publisher: { value: publisher },
    numOfCopies: { value: numofCopies },
  });
  book.counter++;
}
book.counter = 0;

book.bookcounter = function () {
  return book.counter;
};
//-------------------------------------------------------------------------------------------------------------------------------
//   Object.seal(this);
//   Object.freeze(this);
// }

// //*setters of properities
// this.settitle = function (title) {
//   if (typeof title !== "string") throw Error("invalid type");
//   else this.title = title;
// };

// this.setauthor = function (author) {
//   if (typeof author !== "string") throw Error("invalid type");
//   else this.author = author;
// };

// this.setpublisher = function (publisher) {
//   if (typeof publisher !== "string") throw Error("invalid type");
//   else this.publisher = publisher;
// };

// this.setnumofchapters = function (numOfChapters) {
//   if (typeof numofChapters !== "number") throw Error("invalid type");
//   else this.numofChapters = numOfChapters;
// };
// this.setnumofpages = function (numOfPages) {
//   if (typeof numOfPages !== "number") throw Error("invalid type");
//   else this.numofPages = numOfPages;
// };

// this.setnumofcopies = function (numOfCopies) {
//   if (typeof numOfCopies !== "number") throw Error("invalid type");
//   else this.numOfCopies = numOfCopies;
// };

// //*getters of properities
// this.gettitle = function () {
//   return this.title;
// };

// this.getauthor = function () {
//   return this.author;
// };

// this.getpublisher = function () {
//   return this.publisher;
// };

// this.getnumofchapters = function () {
//   return this.numofChapters;
// };
// this.getnumofpages = function () {
//   return this.numofPages;
// };

// this.getnumofcopies = function () {
//   return this.numOfCopies;
// };
