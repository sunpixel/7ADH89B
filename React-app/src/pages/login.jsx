import "./login.css";
import { useNavigate } from 'react-router-dom';

function Login() {
    const navigate = useNavigate();

    function send_data() {
        var username = document.getElementById("username").value;
        var password = document.getElementById("password").value;

        fetch("https://localhost:7095/login", {
            method: "POST",
            body: JSON.stringify({ username: username, password: password }),
        })
            .then((response) => {
                if (response.ok) {
                    // Handle successful response
                    console.log("Request successful");
                    navigate('/profile');
                } else {
                    // Handle error response
                    console.log("Request failed");
                }
            })
            .catch(() => {
                // Handle network error
                console.log("Network error");
            });
    }

    return (
        <div>
            <div className="Login">
                <div className="container">
                    <div className="Typo" id="Welcome">
                        Hi Student
                    </div>
                    <div className="input1">
                        <input id="username" type="text" placeholder="username"></input>
                        <input id="password" type="text" placeholder="password"></input>
                    </div>
                    <div className="btn">
                        <button onClick={send_data}>
                            <div className="Typo">Войти</div>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;