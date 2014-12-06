var express = require('express');
var router = express.Router();
var str2json = require('string-to-json');

/* GET home page. */
router.get('/', function(req, res) {
  console.log(req.body);
  res.json({test1: 'manlok'});
});

router.post('/', function(req, res) {
  console.log(req.body);
  var user = {id: "1", name: "manlok", message: "JsonTesting"}
  var user1 = {id: "2", name: "user2", message: "JsonTesting"}
  var user2 = {id: "3", name: "user3", message: "JsonTesting"}
  // var userJson = JSON.stringify(user);
  // var userJson1 = JSON.stringify(user1);
  var temp = [];
  temp.push(user);
  temp.push(user1);
  temp.push(user2);
  // temp.push("userJson");
  // var data = str2json.convert({id: 1, name: "manlok", message: "JsonTesting"});
  res.send(temp);
  // res.send("userJson");
});

module.exports = router;
