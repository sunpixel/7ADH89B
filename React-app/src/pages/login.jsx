import './login.css'

function window(){
    return (
        <body>
            <div className='Login'>
                <div className='container'>
                    <div className='Typo' id="Welcome">
                        Hi Student
                    </div>
                    <div className='input1'>
                        <input id='username' type='text' placeholder='username'></input>
                        <input id='password' type='text' placeholder='password'></input>
                    </div>
                    <div className='btn'>
                        <button>
                            <div className='Typo'>
                                Войти
                            </div>
                        </button>
                    </div>
                </div>
            </div>
        </body>
    )
}


export default window