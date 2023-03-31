const express = require('express');
const fs = require('fs');
const path = require('path');
const app = express();
const cors = require("cors");

app.use(cors());
let port = process.env.PORT || 7000;

let welcomHtml = fs.readFileSync(path.join(__dirname, '../Client/HTML/Welcom.html')).toString();

let clients = JSON.parse(fs.readFileSync(path.join(__dirname, '../Clients.json')));

app.use(express.urlencoded({ extended: true }));

app.get(['/', '/Index.html', '/Index', '/Client/Index.html', '/Client/Index'], (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/Index.html"));
});

app.get(['/Welcom.html', '/Client/Welcom.html', '/Client/Welcom', '/Welcom'], (req, res) => {
  res.sendFile(path.join(__dirname, '../Client/HTML/Welcom.html'));
});

app.get(['/Style.css', '/Client/Style.css'], (req, res) => {
  res.sendFile(path.join(__dirname, '../Client/Style.css'));
});

app.get(['/Script.js', '/Client/Script.js'], (req, res) => {
  res.sendFile(path.join(__dirname, "../Client/Script.js"));
});

app.get(['/favicon.ico', '/Client/favicon.ico', '/Client/Icons/favicon.ico'], (req, res) => {
  res.sendFile(path.join(__dirname, '../Client/Icons/favicon.ico'));
});

app.get(['/im1.png', '/Client/im1.png', '/Client/img/im1.png','/img/im1.png'], (req, res) => {
  res.sendFile(path.join(__dirname, '../Client/img/im1.png'));
});

app.get(['/getall'], (req, res) => {
  res.send(JSON.stringify(clients));
});

app.post('/', (req, res) => {
  const input = req.body;
  const client = {};
  
  for (const [key, value] of Object.entries(input)) {
    client[key] = value;
  }
  
  clients.push(client);

  fs.writeFile(path.join(__dirname, '../Clients.json'), JSON.stringify(clients, null, 4), (err) => {
    if (err) throw err;

    for (const [key, value] of Object.entries(client)) {
      welcomHtml = welcomHtml.replaceAll(`${key}`, value);
    }
console.log(clients)
    res.send(welcomHtml);
  });
});

app.listen(port, () => {
  console.log(`Server running at http://localhost:${port}`);
});


























// const express = require('express');
// const fs = require('fs');
// const path = require('path');
// const app = express();
// const cors = require("cors");

// app.use(cors());
// let port = process.env.PORT || 7000;


// // let indexHtml = fs.readFileSync("../Client/Index.html").toString();
// let welcomHtml = fs.readFileSync("../Client/HTML/Welcom.html").toString();

// let clients=JSON.parse(fs.readFileSync("../Clients.json"));


// app.use(express.urlencoded({ extended: true }));

// app.get(['/', '/Index.html', '/Index', '/Client/Index.html', '/Client/Index'], (req, res) => {
//   res.sendFile(path.join(__dirname,"../Client/Index.html"));
// });

// app.get(['/', '/Welcom.html', '/Client/Welcom.html', '/Client/Welcom', '/Welcom'], (req, res) => {
//   res.sendFile(path.join(__dirname,'../Client/HTML/Welcom.html'));
// });

// app.get(['/Style.css', '/Client/Style.css'], (req, res) => {
//   res.sendFile(path.join(__dirname,'../Client/Style.css'));
// });

// app.get(['/Script.js', '/Client/Script.js'], (req, res) => {
//   res.sendFile(path.join(__dirname,"../Client/Script.js"));
// });

// app.get(['/favicon.ico', '/Client/favicon.ico', '/Client/Icons/favicon.ico'], (req, res) => {
//   res.sendFile(path.join(__dirname,'../Client/Icons/favicon.ico'));
// })

// app.get(['/im1.png', '/Client/im1.png', '/Client/img/im1.png','/img/im1.png'], (req, res) => {
//     res.sendFile(path.join(__dirname,'../Client/img/im1.png'));
//   })

//   app.get(['/getall'], (req, res) => {
//     res.sendFile(JSON.stringify(clients));
//   })


// app.post('/', (req, res) => {
//   res.render(path.join(__dirname,'Client','HTML','Welcome.html'),req.body);
//     const input = req.body;
//     const client = {};
  
//     for (const [key, value] of Object.entries(input)) {
//       client[key] = value;
//     }
  
//     fs.readFile('../Clients.json', 'utf8', (err, data) => {
     
//         let clients = JSON.parse(data);

//         fs.writeFile('../Clients.json', JSON.stringify(clients, null, 4), () => {});
          
//               for (const [key, value] of Object.entries(clients[0])) {
//                 welcomHtml = welcomHtml.replaceAll(`${key}`, value);
//               }
//       })})

// app.listen(port,()=>{console.log("http://www.localhost:"+port)})












