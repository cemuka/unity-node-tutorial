const express = require('express');
const app = express();

app.get('/', (req, res) => {
    res.send('Hello Unity Developers!');
});

app.listen(3000, () => console.log('started and listening.'));