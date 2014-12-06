var express = require('express');
var path = require('path');
var favicon = require('serve-favicon');
var logger = require('morgan');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var sys = require('sys');
var routes = require('./routes/index');
var users = require('./routes/users');
var app = express(); 
var formidable = require('formidable'),
    http = require('http'),
    util = require('util');
    var     multer  = require('multer')
    var io = require('socket.io');
    var url = require('url');
var color = require('colors');
// http.createServer(function(req, res) {
//   if (req.url == '/upload' && req.method.toLowerCase() == 'post') {
//     // parse a file upload
//     var form = new formidable.IncomingForm();

//     form.parse(req, function(err, fields, files) {
//       res.writeHead(200, {'content-type': 'text/plain'});
//       res.write('received upload:\n\n');
//       res.end(util.inspect({fields: fields, files: files}));
//     });

//     return;
//   }

//   // show a file upload form
//   res.writeHead(200, {'content-type': 'text/html'});
//   res.end(
//     '<form action="/upload" enctype="multipart/form-data" method="post">'+
//     '<input type="text" name="title"><br>'+
//     '<input type="file" name="upload" multiple="multiple"><br>'+
//     '<input type="submit" value="Upload">'+
//     '</form>'
//   );
// }).listen(1111);


// http.createServer(function(request, response) {
//   sys.puts("Someone joined");  
//     response.writeHeader(200, {"Content-Type": "text/plain"});  
//     response.write("Hello World");  
//     response.end();  
// }).listen(1111);    
// }).listen(1111);

// var serv_io = io.listen(server);

// serv_io.sockets.on('connection', function(socket) {
//     socket.emit('message', {'message': 'hello world'});
// });

// io.listen(server); // 開啟 Socket.IO 的 listener

sys.puts("Server Running on 1111");   

// io.listen(1111);

// view engine setup
app.set('views', path.join(__dirname, 'views'));
app.set('view engine', 'jade');

// uncomment after placing your favicon in /public
//app.use(favicon(__dirname + '/public/favicon.ico'));
app.use(logger('dev'));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));
app.use(cookieParser());
app.use(express.static(path.join(__dirname, 'public')));

        app.use(multer({ dest: './uploadss/'}))

app.use('/', routes);
app.use('/users', users);

// catch 404 and forward to error handler
app.use(function(req, res, next) {
    var err = new Error('Not Found');
    err.status = 404;
    next(err);
});

// error handlers

// development error handler
// will print stacktrace
if (app.get('env') === 'development') {
    app.use(function(err, req, res, next) {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: err
        });
    });
}

// production error handler
// no stacktraces leaked to user
app.use(function(err, req, res, next) {
    res.status(err.status || 500);
    res.render('error', {
        message: err.message,
        error: {}
    });
});



app.listen(1111, function() {
    console.log('HTTP server listening on port:' +' 1111'.green);
});

module.exports = app;
