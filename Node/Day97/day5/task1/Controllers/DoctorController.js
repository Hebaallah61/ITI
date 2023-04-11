const doctorModel = require("../Models/DoctorModel");

let getDoctors = async (req, res) => {
    
    let doctors = await doctorModel.find();
    console.log(`hellllllllllllllllllo ${doctors}`);
    res.render('Doctor/doctors', {doctors });
}



let getDoctor = async (req, res) => {
    let doctorId = req.params.id;
    let doctor = await doctorModel.findOne({_id: doctorId}).exec();
    res.render('Doctor/doctor', { doctor });
}

let createPage = async (req, res) => {
    res.render('Doctor/create-doctor');
}

let createDoctor = async (req, res) => {
    let newDoctor = req.body;
    let createdDoctor = await doctorModel.create(newDoctor);
   
    let doctors = await doctorModel.find();
    // console.log(`hellllllllllllllllllo ${doctors}`);
    res.render('Doctor/doctors', {doctors });
}

let updatePage = async (req, res) => {
    let doctorId = req.params.id;
    let doctor = await doctorModel.findOne({_id: doctorId}).exec();
    res.render('Doctor/update-doctor', { doctor });
}

let updateDoctor = async (req, res) => {
    let doctorId = req.params.id;
    let updatedDoctor = req.body;
    let doctor = await doctorModel.findOneAndUpdate({_id: doctorId}, updatedDoctor, {new: true}).exec();
    let doctors = await doctorModel.find();
    res.render('Doctor/doctors', {doctors });
}

let deleteDoctor = async (req, res) => {
    let doctorId = req.params.id;
    await doctorModel.findOneAndDelete({_id: doctorId}).exec();
    
    let doctors = await doctorModel.find();
    res.render('Doctor/doctors', {doctors });
}

module.exports = {
    getDoctors, getDoctor, createPage, createDoctor, updatePage, updateDoctor, deleteDoctor
}
