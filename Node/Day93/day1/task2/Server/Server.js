
const http = require("http");
const fs = require("fs");

const querystring = require('querystring');
let indexHtml = fs.readFileSync("../Client/Index.html").toString();
let welcomHtml = fs.readFileSync("../Client/HTML/Welcom.html").toString();
let errorHtml = fs.readFileSync("../Client/HTML/Error.html").toString();
let styleCSS = fs.readFileSync("../Client/Style.css").toString();
let scriptJS = fs.readFileSync("../Client/Script.js").toString();
let favIcon = fs.readFileSync("../Client/Icons/favicon.ico").toString();
let img = fs.readFileSync("../Client/img/im1.png");
let clients=JSON.parse(fs.readFileSync("../Clients.json"));


http.createServer((req, res)=>{
    console.log(req.url);
    //#region GET
    if(req.method == "GET"){
        switch(req.url){
            case '/':
            case '/Index.html':
            case '/Index':
            case '/Client/Index.html':
            case '/Client/Index':

                res.write(indexHtml);
            break;
            case '/':
            case '/Welcom.html':
            case '/Client/Welcom.html':
            case '/Client/Welcom':
            case '/Welcom':
            
                res.write(welcomHtml);
            break;
            case '/Style.css':
            case '/Client/Style.css':
                res.write(styleCSS);
            break;
            case '/Script.js':
            case '/Client/Script.js':
                    res.write(scriptJS);
            break;
            case '/favicon.ico':
            case '/Client/favicon.ico':
            case '/Client/Icons/favicon.ico':
                        res.write(favIcon);
            break;
            case '/im1.png':
            case '/Client/im1.png':
            case '/Client/img/im1.png':
            case '/img/im1.png':
                        res.write(img);
            break;
            case '/getall':
            console.log(JSON.stringify(clients));
            res.write(JSON.stringify(clients));
            break;
            default:
                
                    res.write(errorHtml);
                
            break;
        }
        res.end();
    }
    //#endregion
    
    //#region POST
    else if(req.method=="POST"){
       
            let body = '';
          
            req.on("data", (data) => {
              body += data.toString();
            });
          
            req.on("end", () => {
              const input = querystring.parse(body);
              const client = {};
          
              for (const [key, value] of Object.entries(input)) {
                client[key] = value;
              }
          
              clients.unshift(client);
          
              fs.writeFile('../Clients.json', JSON.stringify(clients, null, 4), () => {});
          
              for (const [key, value] of Object.entries(clients[0])) {
                welcomHtml = welcomHtml.replaceAll(`${key}`, value);
              }
          
              res.write(welcomHtml);
              res.end();

        })
    }
    //#endregion
   
    
    
    //#region Default
    else{
        res.end("Please Select Common Method");
    }
    //#endregion
}).listen(7000,()=>{console.log("Listining on Port 7000")})