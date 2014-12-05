var express = require('express');
var router = express.Router();
var str2json = require('string-to-json');

/* GET home page. */
router.get('/', function(req, res) {
  console.log(req.body);
  res.json({test1: 'manlok'});
});

router.post('/', function(req, res) {
  console.log(req.body.test);
  var user = {id: 1, name: "manlok", message: "JsonTesting"}
  var userJson = JSON.stringify(user);
  // var data = str2json.convert({id: 1, name: "manlok", message: "JsonTesting"});
  res.send(userJson);
  res.send("abd321");
});

module.exports = router;
