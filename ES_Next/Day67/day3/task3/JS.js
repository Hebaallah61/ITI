/**
 3) Promise
 Create your function that takes url of required service to be 
 consumed and return a promise.
 Make ajax request using your function to consume the 
 service of the following link 
 “https://jsonplaceholder.typicode.com/users”
 Display its output in a table style your website via 
 bootstrap
 */

/*Asy
 //? Fetch API
 //? Timer
 //? Event
 //? Ajax
*/
var tb = document.getElementById("tb");
async function getinfo(url) {
  var re = await fetch(url);
  var r = await re.json();
  let ro = "";
  for (let i = 0; i < r.length; i++) {
    ro += `<tr>
        <td>${r[i].id}</td>
        <td>${r[i].name}</td>
        <td>${r[i].username}</td>
        <td>${r[i].email}</td>
        <td>${r[i].address.street}</td>
        <td>${r[i].address.city}</td>
        <td>${r[i].address.suite}</td>
        <td>${r[i].company.name}</td>
        <td>${r[i].phone}</td>
        <td><a href=http://www.${r[i].website}>${r[i].website}</a></td>
        
        </tr>`;
  }
  tb.innerHTML = ro;
}
getinfo("https://jsonplaceholder.typicode.com/users");

// var mypromise = new Promise(function (c, f) {
//   var hr = new XMLHttpRequest();
//   hr.open("Get", "https://jsonplaceholder.typicode.com/users");
//   hr.onreadystatechange = function () {
//     if (hr.readyState == 4) {
//       if (hr.status == 200) {
//         //   var data = JSON.parse(hr.responseText);
//         //   console.log(data);
//         c(hr.responseText);
//       } else {
//         f("invalid");
//       }
//     }
//   };
//   hr.send("");
// })
//   .then(function (data) {
//     var info = JSON.parse(data);
//     console.log(info);
//   })
//   .catch(function (m) {
//     console.log(m);
//   });
