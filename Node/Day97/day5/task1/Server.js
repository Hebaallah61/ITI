//#region Requires
const express = require("express");
const app = express();
const path = require("path");
const bodyParser = require("body-parser");
const PORT = process.env.PORT||7010;
//#endregion

//#region MiddleWares
app.use(bodyParser.urlencoded({extended:true}));
app.use(bodyParser.json());
app.set('view engine', 'ejs');

//#endregion

//#region End Points
 //#region Auth [Registration - Login]
   const UsersRoutes = require("./Routes/UsersRoutes");
        app.use("/users", UsersRoutes);
        app.use("", UsersRoutes);
    //#endregion
    //#region doctors Routes
    const DoctorRoutes = require("./Routes/DoctorRoutes");
    app.use("/doctors", DoctorRoutes);
    //#endregion

    //#region patients
    const PatientRoutes = require("./Routes/PatientRoutes");
    app.use("/patients",PatientRoutes);
    //#endregion

   

//#endregion

app.listen(PORT, ()=>{console.log("http://localhost:"+PORT)});
