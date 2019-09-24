const express = require('express');
const app = express();
app.use(express.json());

app.get('/', (req, res) => {
    res.send('Hello Unity Developers!');
});

let enemies = [
	{
		"id": 0,
		"name": "orc",
		"health": 100,
		"attack": 25
	},
	{
		"id": 1,
		"name": "wolf",
		"health": 110,
		"attack": 25
	}
];

app.get('/enemy', (req, res) => {
    res.send(enemies);
});

app.post('/enemy/create', (req, res) => {
	let newEnemy = {
		"id": req.body.id,
		"name": req.body.name,
		"health": req.body.health,
		"attack": req.body.attack
	};

	enemies.push(newEnemy);
	console.log(enemies);
	res.send(enemies);
});

app.listen(3000, () => console.log('started and listening.'));