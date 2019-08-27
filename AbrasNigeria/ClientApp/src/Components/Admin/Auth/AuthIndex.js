import React from "react";
import { NavLink } from "react-router-dom";

import AbrasLogo from "../../../Images/abrasLogo.png";

const AuthIndex = ({ children }) => {
  return (
    <React.Fragment>
      <header>
        <nav className="navbar navbar-expand-lg navbar-light bg-light shadow-sm mb-2">
          <a
            className="navbar-brand font-weight-bolder text-primary text-uppercase "
            href="/guest/home"
          >
            <img
              src={AbrasLogo}
              alt="Abras"
              height="30px"
              className="pr-2 align-middle"
            />
            <span className="align-middle">Abras</span>
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-toggle="collapse"
            data-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon" />
          </button>

          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav ml-auto">
              <li className="nav-item ">
                <NavLink to="/guest/home" active ClassName="active">
                  <div className="nav-link">
                    Login <span className="sr-only">(current)</span>
                  </div>
                </NavLink>
              </li>
            </ul>
          </div>
        </nav>
      </header>
      <div className="container py-5">{children}</div>
    </React.Fragment>
  );
};

export default AuthIndex;
