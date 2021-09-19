import  React from 'react';

function Login() {
    return (
        <div className="content-center items-center">
            <form>
                <h1>Please sign-in</h1>
                <input type="email" placeholder="Email address" required autoFocus/>
                <input type="password" placeholder="Password" required/>
                <button type="submit">Sign in</button>
            </form>
        </div>
    );
}

export default Login;