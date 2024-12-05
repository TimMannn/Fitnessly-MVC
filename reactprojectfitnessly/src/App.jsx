import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import Login from './Login';
import Register from './Register';
import CRUD from './Workout';
import './App.css';

function App() {
    const isAuthenticated = () => {
        // Voeg je authenticatielogica toe, bijvoorbeeld controleer een token in localStorage
        return localStorage.getItem("token") !== null;
    };

    return (
        <Router>
            <div className="App">
                <Routes>
                    <Route path="/login" element={isAuthenticated() ? <Login /> : <Navigate to="/Login" />} />
                    <Route path="/register" element={isAuthenticated() ? <Register /> : <Navigate to="/Register" />} />
                    <Route path="/workout" element={isAuthenticated() ? <CRUD /> : <Navigate to="/Workout" />} />
                    <Route path="/" element={<Navigate to="/login" />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;
