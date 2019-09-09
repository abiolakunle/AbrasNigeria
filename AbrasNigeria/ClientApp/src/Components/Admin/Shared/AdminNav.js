import React from "react";
import { NavLink } from "react-router-dom";

import { logout } from "../../../Actions/authActions";

import logo from "../../../Images/abrasLogo.png";
import "./AdminNav.css";

const DashboardIndex = ({ children }) => {
  return (
    <React.Fragment>
      <div id="wrapper" className="toggled">
        <div id="sidebar-wrapper">
          <ul className="sidebar-nav">
            <li className="sidebar-brand">
              <NavLink to="/">
                {" "}
                <img src={logo} alt="Abras" height="30px" /> Abras
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/dashboard">Dashboard</NavLink>
            </li>
            <li>
              <NavLink to="/admin/document/list">Document list</NavLink>
            </li>
            <li>
              <NavLink to="/admin/document/new">Create New Document</NavLink>
            </li>
            <li>
              <NavLink to="/admin/stock/list">Store</NavLink>
            </li>
            <li>
              <NavLink to="/admin/stock/create">Create Product</NavLink>
            </li>

            <li>
              <button className="btn btn-secondary" onClick={logout}>
                Logout
              </button>
            </li>
          </ul>
        </div>

        <div id="page-content-wrapper">
          <div className="container-fluid">{children}</div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default DashboardIndex;
