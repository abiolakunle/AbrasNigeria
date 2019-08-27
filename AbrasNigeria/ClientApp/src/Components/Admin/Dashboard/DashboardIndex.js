import React from "react";
import { NavLink } from "react-router-dom";

import logo from "../../../Images/abrasLogo.png";
import "./Dasboard.css";

const DashboardIndex = ({ children }) => {
  return (
    <React.Fragment>
      <div id="wrapper" class="toggled">
        <div id="sidebar-wrapper">
          <ul class="sidebar-nav">
            <li class="sidebar-brand">
              <NavLink to="/">
                {" "}
                <img src={logo} alt="Abras" height="30px" /> Abras
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/document/list">Document list</NavLink>
            </li>
            <li>
              <li>
                <NavLink to="/admin/document/new">Create New Document</NavLink>
              </li>
            </li>
            <li>
              <li>
                <NavLink to="/admin/document/list">Manage Stock</NavLink>
              </li>
            </li>
            <li>
              <li>
                <NavLink to="/auth/login">Login</NavLink>
              </li>
            </li>
          </ul>
        </div>

        <div id="page-content-wrapper">
          <div class="container-fluid">{children}</div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default DashboardIndex;
