import React from "react";
import { NavLink, withRouter } from "react-router-dom";

import "./sideNavbar.css";

import { logout } from "../../../Actions/authActions";

import logo from "../../../Images/abrasLogo.png";

const SideNavbar = ({ children }) => {
  return (
    <React.Fragment>
      <div id="wrapper" class="active">
        <div id="sidebar-wrapper">
          <ul id="sidebar_menu" class="sidebar-nav">
            <li class="sidebar-brand">
              <a
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
                <span class="fas fa-bars sub_icon"></span>
              </a>
            </li>
          </ul>
          <ul class="sidebar-nav" id="sidebar">
            <li className="sidebar-brand">
              <NavLink to="/">
                Abras home{" "}
                <img
                  src={logo}
                  alt="Abras"
                  height="40px"
                  className="sub_icon"
                />
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/dashboard">
                Dashboard <span class="fas fa-link sub_icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/document/list">
                Document list <span class="fas fa-link sub_icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/document/new">
                New Document <span class="fas fa-link sub_icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/stock/list">
                Store <span class="fas fa-link sub_icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/stock/create">
                Create Product <span class="fas fa-link sub_icon"></span>
              </NavLink>
            </li>
            <li>
              <NavLink to="/admin/upload/excel">
                Upload excel <span class="fas fa-link sub_icon"></span>
              </NavLink>
            </li>

            <li>
              <NavLink onClick={logout}>
                Logout <span class="fas fa-sign-out-alt sub_icon"></span>
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
