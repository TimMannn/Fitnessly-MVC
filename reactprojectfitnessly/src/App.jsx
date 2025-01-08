import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import Login from "./Login";
import Register from "./Register";
import CRUD from "./Workout";
import Exercise from "./Exercise";
import WorkoutSessie from "./WorkoutSessie";

function App() {
  const isAuthenticated = () => {
    return localStorage.getItem("token") !== null;
  };

  return (
    <Router>
      <div className="App">
        <Routes>
          {/* Route voor inloggen */}
          <Route path="/login" element={<Login />} />

          {/* Route voor registreren */}
          <Route path="/register" element={<Register />} />

          {/* Route voor workout - beveiligd met authenticatie */}
          <Route
            path="/workout"
            element={isAuthenticated() ? <CRUD /> : <Navigate to="/login" />}
          />

          {/* Route voor exercise met workoutId als parameter - beveiligd met authenticatie */}
          <Route
            path="/exercise/:workoutId/:workoutName?"
            element={
              isAuthenticated() ? <Exercise /> : <Navigate to="/login" />
            }
          />

          <Route
            path="/workoutsessie/:workoutId/:workoutName?/:workoutSessieId?"
            element={
              isAuthenticated() ? <WorkoutSessie /> : <Navigate to="/login" />
            }
          />

          {/* Standaard route naar login */}
          <Route path="/" element={<Navigate to="/login" />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
