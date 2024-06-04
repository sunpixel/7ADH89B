import "./css/login.css";
import { useNavigate } from 'react-router-dom';

function Login() {
    const navigate = useNavigate();

    async function send_data() {

        if (!document.getElementById("username").value && !document.getElementById("password").value) {
            alert("Please enter username and password");
            return;
        }

        else if (!document.getElementById("username").value) {
            alert("Please enter username");
            return;
        }
        else if (!document.getElementById("password").value) {
            alert("Please enter password");
            return;
        }

        var username = document.getElementById("username").value;
        var password = document.getElementById("password").value;

        try {
            const response = await fetch("https://localhost:7128/api/login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({ username: username, password: password }),
            });

            if (response.ok) {
                // Handle successful response
                console.log("Request successful");
                const data = await response.json();
                // Pass the id to the profile component via navigation state
                const id = data.userId;
                console.log("Received id:", id);
                navigate('/profile', { state: { id } });
            } else {
                // Handle error response
                console.log("Request failed");
                const errorCode = response.status;
                alert(`Connection refused. Error code: ${errorCode}`);
            }
        } catch (error) {
            // Handle network error
            alert(`Network error. ${error}`);
            console.log("Network error");
        }
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
