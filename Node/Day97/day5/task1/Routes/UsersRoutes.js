
const express = require("express");
const router = express.Router();
const UsersController = require("../Controllers/UsersController");


router.get("", UsersController.registerHome);
router.get("/register", UsersController.registerHome);
router.get("/login", UsersController.loginHome);

router.post("/register", UsersController.register);
router.post("/login", UsersController.login);

module.exports = router;
