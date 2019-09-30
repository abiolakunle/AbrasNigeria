import React from "react";
import { NavLink, withRouter } from "react-router-dom";

import "./sideNavbar.css";

import { logout } from "../../../Actions/authActions";
import Authorize from "../Shared/Authorize";
import userService from "../../../Services/userService";

import logo from "../../../Images/abrasLogo.png";

const SideNavbar = ({ children }) => {
  return (
    <React.Fragment>
      <div id="wrapper" className="active">
        <div id="sidebar-wrapper">
          <ul id="sidebar_menu" className="sidebar-nav">
            <li className="menu-btn">
              <button
                onClick={event => {
                  event.preventDefault();
                  const wrapper = document.querySelector("#wrapper");
                  if (wrapper.classList.contains("active")) {
                    wrapper.classList.remove("active");
                  } else {
                    wrapper.classList.add("active");
                  }
                }}
              >
                Menu
                <span className="fas fa-bars sub-icon"></span>
              </button>
            </li>
          </ul>
          <ul className="sidebar-nav" id="sidebar">
            <li className="sidebar-brand">
              <NavLink to="/">
                Abras home{" "}
                <img
                  src={logo}
                  alt="Abras"
                  height="40px"
                  className="sub-icon"
                />
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/dashboard">
                Dashboard <span className="fas fa-link sub-icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/document/list">
                Document list <span className="fas fa-link sub-icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/document/new">
                New Document <span className="fas fa-link sub-icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/stock/list">
                Store <span className="fas fa-link sub-icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/stock/create">
                Create Product <span className="fas fa-link sub-icon"></span>
              </NavLink>
            </li>
            <Authorize role={userService.roles.SUPER_ADMIN}>
              <li>
                <NavLink to="/admin/auth/register">
                  Create User <span className="fas fa-link sub-icon"></span>
                </NavLink>
              </li>
            </Authorize>
            <li>
              <NavLink to="/admin/upload/excel">
                Upload excel <span className="fas fa-link sub-icon"></span>
              </NavLink>
            </li>

            <li>
              <NavLink onClick={logout}>
                Logout <span className="fas fa-sign-out-alt sub-icon"></span>
              </NavLink>
            </li>
          </ul>
        </div>

        <div id="page-content-wrapper">
          <div className="container py-5"> {children}</div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default withRouter(SideNavbar);
