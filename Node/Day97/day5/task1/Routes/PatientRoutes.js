const express = require("express");
const router = new express.Router();
const PatientController = require("../Controllers/PatientController");

router.get("", PatientController.getPatients);
router.get("/create", PatientController.createPage);
router.get("/update/:id", PatientController.updatePage);
router.get("/:id", PatientController.getPatient);

router.post("/create", PatientController.createPatient);
router.post("/update/:id", PatientController.updatePatient);
router.get("/delete/:id", PatientController.deletePatient);

module.exports = router;