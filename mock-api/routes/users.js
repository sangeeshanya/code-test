var express = require('express');
var router = express.Router();
var path = require('path');
var fs = require('fs');

router.get('/:id', function(req, res, next) {
  fs.readFile(path.join(__dirname, `../data/users/${req.params.id}`), (err, data) => {
    if (err && err.code === 'ENOENT') {
      res.status(404).end();
      return;
    }

    res.header('content-type', 'application/json');

    if (err) {
      res.status(500).send(JSON.stringify(err));
      return;
    }

    res.send(data);
  })
});

router.post('/:id', function(req, res, next) {
  if (typeof(req.body.balance) !== 'number') {
    res.status(400).end();
    return;
  }

  fs.writeFile(path.join(__dirname, `../data/users/${req.params.id}`), `{"balance":${req.body.balance}}`, (err) => {
    if (err && err.code === 'ENOENT') {
      res.status(404).end();
      return;
    }

    res.header('content-type', 'application/json');

    if (err) {
      res.status(500).send(JSON.stringify(err));
      return;
    }

    res.status(200).end();
  })
});

module.exports = router;
