import { useState } from 'react';
import axios from 'axios';
import { useNavigate, Link } from 'react-router-dom';

const Login = () => {
    const [userName, setUserName] = useState('');
    const [password, setPassword] = useState('');
    const [rememberMe, setRememberMe] = useState(false);
    const [message, setMessage] = useState('');
    const navigate = useNavigate();

    const handleLogin = async () => {
        try {
            const response = await axios.post('https://your-api-url/api/account/login', {
                userName,
                password,
                rememberMe
            });
            localStorage.setItem("token", "your-authentication-token"); // Opslaan van token
            setMessage(response.data.Result);
            navigate("/workout");
        } catch (error) {
            console.error('Error details:', error.response);
            setMessage('Login failed');
        }
    };

    return (
        <div>
            <h2>Login</h2>
            <input
                type="text"
                placeholder="Username"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
            />
            <input
                type="password"
                placeholder="Password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <label>
                <input
                    type="checkbox"
                    checked={rememberMe}
                    onChange={(e) => setRememberMe(e.target.checked)}
                />
                Remember me
            </label>
            <button onClick={handleLogin}>Login</button>
            {message && <p>{message}</p>}
            <p>Dont have an account? <Link to="/register">Register here</Link></p>
        </div>
    );
};

export default Login;
