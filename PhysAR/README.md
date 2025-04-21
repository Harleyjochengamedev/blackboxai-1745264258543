# PhysAR: A Física em Suas Mãos

## Project Overview
PhysAR is an interactive physics simulator with augmented reality (AR) and machine learning (ML) for Android devices. It allows users to visualize and interact with physics experiments in 3D using their mobile device camera.

## Key Features
- AR visualization of physics experiments (Newton's laws, projectile motion, electric and magnetic fields, pendulums)
- Real-time object recognition using ML (TensorFlow Lite / MediaPipe)
- Physics simulation using Unity Physics Engine
- Data storage with Firebase or SQLite
- Quiz mode with interactive challenges
- Experiment creator mode
- Online leaderboard via REST API and Node.js backend
- Beautiful and intuitive UI with smooth transitions

## Technologies Used
- Unity with AR Foundation (cross-platform AR)
- C# with Unity Physics Engine
- TensorFlow Lite / MediaPipe for ML object recognition
- Firebase / SQLite for data persistence
- Node.js REST API for online features
- Python for ML model training

## Project Structure
- `UnityApp/` - Unity project with AR and physics simulation
- `MLModels/` - Python scripts and data for training ML models
- `Backend/` - Node.js REST API server
- `WebDashboard/` - Web app for leaderboard and stats
- `Docs/` - Documentation and design notes

## Setup Instructions
1. Install Unity with AR Foundation support.
2. Clone this repository.
3. Open `UnityApp` in Unity Editor.
4. Follow the README files in each subfolder for detailed setup.

### Backend Setup
- Ensure you have Node.js and Python installed.
- Navigate to the `PhysAR/Backend` directory.
- Initialize the SQLite database by running:
  ```
  python3 init_db.py
  ```
- Install Node.js dependencies (if any) and start the backend server:
  ```
  npm install express sqlite3
  node server.js
  ```
- The backend server will run on port 3000 by default.

## Development Roadmap
- Phase 1: Basic AR setup and physics simulation prototypes
- Phase 2: ML integration for object recognition
- Phase 3: Data storage and quiz mode implementation
- Phase 4: Backend API and web dashboard development
- Phase 5: UI polish, testing, and deployment

## Contact
For questions or contributions, please contact the project maintainer.
