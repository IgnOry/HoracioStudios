//import express from 'express';
var express = require('express');
const server = express();

const port = 25565;

var cont = 0;

// /start significa que se envia 
server.get('/start', (req, res) => {
  cont+=1;
  return res.send(cont.toString());
})

server.listen(port, () => {
  console.log(`Server is running on port ${port}`);
});