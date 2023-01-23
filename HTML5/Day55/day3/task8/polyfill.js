conditionizr.add("noCookie", function () {
  return !window.cookie;
});
conditionizr.polyfill("./cookie/JSsheet_Cookie.js", ["noCookie"]);
