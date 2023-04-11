// const userModel = require("../Models/UsersModel");
// const bcrypt = require("bcrypt");


// let RegisterHome = async (req, res) => {
//     res.render('../Shared/Register.html')
// }

// let LoginHome = async (req, res) => {
//     res.render('../Shared/Login.html')
// }

// let Register = async (req,res)=>{
    
//     let newUser = req.body;
//     let foundUser = await userModel.findOne({email:newUser.email}).exec();
//     if(foundUser) return res.status(401).json({message:"User Already Exist"});

//     //Hash Password [npm i bcrypt]
//     let genSalt = await bcrypt.genSalt(10);
//     let hashedPassword = await bcrypt.hash(newUser.password, genSalt);
//     newUser.password = hashedPassword;

//     let newUSER = new userModel(newUser);
//     await newUSER.save();

//     return res.status(201).json({message:"User Added Successfully",data:newUSER});

// }


// let  Login = async (req,res)=>{
   
//     let logUser = req.body;
//     let foundUser = await userModel.findOne({email:logUser.email}).exec();
//     if(!foundUser) return res.status(401).json({message:"Invalid Email Or Password"});

    
//     let checkPass = bcrypt.compareSync(logUser.password, foundUser.password);
//     if(!checkPass) return res.status(401).json({message:"Invalid Email Or Password"});

    

// }



// module.exports = {
//     Register, RegisterHome,  Login, LoginHome
// }


const userModel = require("../Models/UsersModel");
const bcrypt = require("bcrypt");

let registerHome = async (req, res) => {
    // res.render('register');
    res.render('register', { title: 'Registration' });
}

let loginHome = async (req, res) => {
    res.render('login');
}

let register = async (req,res)=>{
    let newUser = req.body;
    let foundUser = await userModel.findOne({email:newUser.email}).exec();
    if(foundUser) return res.render('error.ejs', {message: "User Already Exist"});
    // Hash Password [npm i bcrypt]
    let genSalt = await bcrypt.genSalt(10);
    let hashedPassword = await bcrypt.hash(newUser.password, genSalt);
    newUser.password = hashedPassword;
    let newUSER = new userModel(newUser);
    await newUSER.save();
    res.redirect('/doctors/');   //res.status(201).json({message:"User Added Successfully",data:newUSER});
}

let login = async (req,res)=>{
    let logUser = req.body;
    let foundUser = await userModel.findOne({email:logUser.email}).exec();
    if(!foundUser) return res.render('error.ejs', {message: "Invalid Email Or Password"});
    let checkPass = bcrypt.compareSync(logUser.password, foundUser.password);
    if(!checkPass) return res.render('error.ejs', {message: "Invalid Email Or Password"});
 
    
    res.redirect('/doctors/')        
   // return res.render('Doctor/doctors.ejs');
}

module.exports = {
    register, registerHome,  login, loginHome
}


