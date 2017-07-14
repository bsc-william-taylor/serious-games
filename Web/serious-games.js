
const connections = require('./connections.js');
const bodyParser = require('body-parser');
const express = require('express');
const request = require('request');
const app = express();

const port = () => Number(process.argv.slice(-1)[0]);

const simpleGet = (url, res) => {
  request(url, (error, response, body) => {
    if (!error && response.statusCode == 200) {
      res.json(JSON.parse(body));
    } else {
      res.json({ "msg": "Error getting information" });
    }
  })
}

const simplePost = (url, body, res) => {
  request.post({ url, body: JSON.stringify(body) }, (error, response, body) => {
    if (!error && response.statusCode == 200) {
      if (res) res.json(JSON.parse(body));
    } else {
      if (res) res.json({ "msg": "Error getting information" });
    }
  })
}

app.use(bodyParser.json());
app.post('/action-gameplay', (req, res) => {
  const gameplay = req.body.gameplayID;
  const action = req.body.type;

  let json = {};

  switch (action) {
    case 'safety':
      json = { "action": "foundSafetyItem", "values": { "type": "safety" } };
      break;

    case 'hazards':
      json = { "action": "foundHazardItem", "values": { "type": "hazard" } };
      break;

    case 'evac':
      json = { "action": "escaped", "values": { "action": "escaped" } };
      break;

    case 'fires':
      json = { "action": "firePutOut", "values": { "fire": "fire" } };
      break;

    default:
      break;
  }

  if (Object.keys(json).length > 0) {
    simplePost(connections.assess(gameplay), json, null);
  } else {
    res.json({ 'msg': 'success' });
  }
});

app.post('/start-gameplay', (req, res) => {
  const student = req.body.student;
  const guest = req.body.guest;

  let json = {};

  if (!student) {
    json = {
      idSG: connections.uniqueIdentifier,
      version: connections.version,
      idStudent: 0,
      params: [
        { name: "name", type: "String", value: guest.name },
        { name: "age", type: "Int", value: Number(guest.age) },
        { name: "gender", type: "String", value: guest.gender }
      ]
    };
  } else {
    json = {
      idSG: connections.uniqueIdentifier,
      version: connections.version,
      idPlayer: student.idPlayer
    }
  }

  simplePost(connections.gs, json, res);
});

app.post('/success-gameplay', (req, res) => {
  const gameplayID = req.body.gameplayID;
  const url = connections.gameWin(gameplayID);

  res.json({});
});

app.post('/fail-gameplay', (req, res) => {
  const gameplayID = req.body.gameplayID;
  const url = connections.gameLose(gameplayID);

  res.json({});
});

app.post('/get-badges', (req, res) => {
  const username = req.body.username;
  const badges = [];

  res.json({ 'badges': badges });
});

app.post('/login-student', (req, res) => {
  const body = {
    idSG: connections.uniqueIdentifier,
    username: req.body.username,
    password: req.body.password
  };

  res.json({ version: 'dummy', idPlayer: 1 });
});

app.post('/login-guest', (req, res) => {
  const body = {
    idSG: connections.uniqueIdentifier,
    username: "",
    password: ""
  };

  res.json({ version: 'dummy' });
});

app.get('/leaderboard', (req, res) => {
  const response = {
    json: body => {
      const noDuplicates = [];

      body.fires_put_out.forEach(person => {
        const found = noDuplicates.find(value => {
          return (value.name === person.name);
        });

        if (found == undefined) {
          noDuplicates.push(person);
        }
      });

      body.fires_put_out = noDuplicates;
      res.json(body);
    }
  };

  res.json({ fires_put_out: [] });
});

app.get('/info', (req, res) => {
  res.json({ "info": "info" });
});

app.get('/logs', (req, res) => {
  res.json({ "logs": "logs" });
});

app.get('/', (req, res) => {
  const html = `
    <html>
      <body>
        <h1>Server online</h1>
      </body>
    </html>
  `;

  res.setHeader('Content-Type', 'text/html');
  res.write(html);
  res.end();
});

app.listen(port(), () => {
  console.log('Server online')
});