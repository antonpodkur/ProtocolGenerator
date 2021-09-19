import {Link} from 'react-router-dom';

function Navbar() {
    return (
        <div className="flex h-8 bg-green-500 text-white items-center justify-end">
                <div className="font-bold flex-1 ml-2">
                    <Link to="/">Protocol Generator</Link>
                </div>
                <ul className="flex mr-2">
                    <li className="mx-2">
                        <Link to="/login">Login</Link>
                    </li>
                    <li className="mx-2">
                        <Link to="/register">Register</Link>
                    </li>
                    <li className="mx-2">Logout</li>
                </ul>
        </div>
    );
}

export default Navbar;