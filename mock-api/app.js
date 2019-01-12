var express = require('express');
var logger = require('morgan');

var usersRouter = require('./routes/users');
var betsRouter = require('./routes/bets');

var app = express();

app.use(logger('dev'));
app.use(express.json());
app.use(express.urlencoded({ extended: false }));

app.use('/users', usersRouter);
app.use('/bets', betsRouter);

module.exports = app;
