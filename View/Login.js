import { bottom } from '@popperjs/core'
import React, { useState, useEffect } from 'react'
import { useHistory } from 'react-router-dom'
import Header from './Header'
function Login() {
    const [Username, setUsername] = useState("")
    const [Password, setPassword] = useState("")
    const History = useHistory();
    useEffect(() => {
        if (localStorage.getItem('UserInfo')) {
            history.push("/add")
        }
    }, [])
   async function login()
    {
        console.warn(Username, Password);
        let item = (Username, Password);
       let result = await fetch("http://localhost:8000/api/Users", {
           method = 'POST',
           headers: {
               "Content-Type": "aplication/json",
               "Accept": "aplication/json"
           },
           body: JSON.stringify(item)
       });
       result = await result.json();
       localStorage.setItem(JSON.stringify(result))
       history.push("/add")
    }
return (
    <div>
        <Header />
        <h1>Login Page</h1>
        <div classname="col-sm-6 offset-sm-3">
            <input type="Text" placeholder="Username"
                onChange={(e) => setUsername(e.target.value)}
                className="form-control" />
            <br />
            <input type="Password" placeholder="Password"
                onChange={(e) => setPassword(e.target.value)}

            className="form-control" />
            <br />
            <button onClick="login" className="btn btn-Primary">Login</button>
        </div>
        </div>
    )