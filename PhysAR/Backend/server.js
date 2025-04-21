const express = require('express');
const sqlite3 = require('sqlite3').verbose();
const app = express();
const port = process.env.PORT || 3000;

app.use(express.json());

// Simple in-memory user store for demo
const users = {
    'admin': 'password123',
    'user1': 'pass1'
};

// Open SQLite database
const db = new sqlite3.Database('./physar.db', (err) => {
    if (err) {
        console.error('Could not connect to database', err);
    } else {
        console.log('Connected to SQLite database');
    }
});

// Login endpoint
app.post('/login', (req, res) => {
    const { username, password } = req.body;
    if (users[username] && users[username] === password) {
        // In real app, generate token or session
        res.json({ status: 'success', message: 'Logged in' });
    } else {
        res.status(401).json({ status: 'fail', message: 'Invalid credentials' });
    }
});

// Logout endpoint (dummy for demo)
app.post('/logout', (req, res) => {
    // In real app, destroy session or token
    res.json({ status: 'success', message: 'Logged out' });
});

// Placeholder route for leaderboard
app.get('/leaderboard', (req, res) => {
    db.all('SELECT user, score FROM quiz_scores ORDER BY score DESC LIMIT 10', [], (err, rows) => {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        }
        res.json({ leaderboard: rows });
    });
});

// Save quiz score
app.post('/quiz-score', (req, res) => {
    const { user, score } = req.body;
    const sql = 'INSERT INTO quiz_scores (user, score) VALUES (?, ?)';
    db.run(sql, [user, score], function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        }
        res.json({ status: 'success', id: this.lastID });
    });
});

// Save experiment data
app.post('/experiment', (req, res) => {
    const experimentData = JSON.stringify(req.body);
    const sql = 'INSERT INTO experiments (data) VALUES (?)';
    db.run(sql, [experimentData], function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        }
        res.json({ status: 'success', id: this.lastID });
    });
});

app.listen(port, () => {
    console.log(`Backend server running on port ${port}`);
});
