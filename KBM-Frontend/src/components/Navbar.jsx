import { NavLink, Link } from "react-router-dom";

function Navbar() {
  return (
    <nav className="navbar">
      <div className="navbar-container">

        <Link to="/" className="logo">
          Advansys
        </Link>

        <div className="nav-links">

          <NavLink to="/">
            Home
          </NavLink>

          <NavLink to="/lessons">
            Lessons Learned
          </NavLink>

          <NavLink to="/chatbot">
            Chatbot
          </NavLink>

          <NavLink to="/create-lesson">
            Create Lesson
          </NavLink>

        </div>

      </div>
    </nav>
  );
}

export default Navbar;