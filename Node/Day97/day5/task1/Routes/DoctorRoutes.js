const express = require("express");
const router = new express.Router();
const DoctorController = require("../Controllers/DoctorController");
const UsersController = require("../Controllers/UsersController");
// /doctors
router.get("", DoctorController.getDoctors);

router.get("/create", DoctorController.createPage);
router.get("/update/:id", DoctorController.updatePage);
router.get("/:id", DoctorController.getDoctor);

router.post("/create", DoctorController.createDoctor);
router.post("/update/:id", DoctorController.updateDoctor);
router.get("/delete/:id", DoctorController.deleteDoctor);

module.exports = router;