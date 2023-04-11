const patientModel = require("../Models/PatientModel");

let getPatients = async (req, res) => {
    let patients = await patientModel.find();
    console.log(`hellllllllllllllllllo`);
    res.render('Patient/patients', { patients });
}



let getPatient = async (req, res) => {
    let patientId = req.params.id;
    let patient = await patientModel.findOne({_id: patientId}).exec();
    res.render('Patient/patient', { patient });
}

let createPage = async (req, res) => {
    res.render('Patient/create-patient');
}

let createPatient = async (req, res) => {
    let newPatient = req.body;
    let createdPatient = await patientModel.create(newPatient);
    let patients = await patientModel.find();
    res.render('Patient/patients', { patients });
}

let updatePage = async (req, res) => {
    let patientId = req.params.id;
    let patient = await patientModel.findOne({_id: patientId}).exec();
    res.render('Patient/update-patient', { patient });
}

let updatePatient = async (req, res) => {
    let patientId = req.params.id;
    let updatedPatient = req.body;
    let patient = await patientModel.findOneAndUpdate({_id: patientId}, updatedPatient, {new: true}).exec();
    let patients = await patientModel.find();
    res.render('Patient/patients', { patients });
}

let deletePatient = async (req, res) => {
    let patientId = req.params.id;
   await patientModel.findOneAndDelete({_id: patientId}).exec();
   let patients = await patientModel.find();
   res.render('Patient/patients', { patients });
}

module.exports = {
    getPatients, getPatient, createPage, createPatient, updatePage, updatePatient, deletePatient
}
