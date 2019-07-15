import React, { Component } from "react";
import { NavLink } from "react-router-dom";

class GuestHeader extends Component {
  render() {
    return (
      <nav className="navbar navbar-expand-lg navbar-light bg-light shadow-sm mb-2">
        <a
          className="navbar-brand font-weight-bolder text-primary text-uppercase"
          href="/"
        >
          Abras
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
              <NavLink to="/guest/home" activeClassName="active">
                <div className="nav-link">
                  Home <span className="sr-only">(current)</span>
                </div>
              </NavLink>
            </li>
            <li className="nav-item ">
              <NavLink exact to="/guest/categories" activeClassName="active">
                <div className="nav-link">
                  Categories <span className="sr-only">(current)</span>
                </div>
              </NavLink>
            </li>
            <li className="nav-item ">
              <NavLink to="/guest/brands" activeClassName="active">
                <div className="nav-link">
                  Brands <span className="sr-only">(current)</span>
                </div>
              </NavLink>
            </li>
            <li className="nav-item ">
              <NavLink to="/guest/machines" activeClassName="active">
                <div className="nav-link">
                  Machines <span className="sr-only">(current)</span>
                </div>
              </NavLink>
            </li>
            <li className="nav-item ">
              <NavLink to="/guest/contact" activeClassName="active">
                <div className="nav-link">
                  Contact <span className="sr-only">(current)</span>
                </div>
              </NavLink>
            </li>
          </ul>
          <form className="form-inline my-2 my-lg-0">
            <input
              className="form-control mr-sm-2"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
            <button
              className="btn btn-outline-primary my-2 my-sm-0"
              type="submit"
            >
              Search
            </button>
          </form>
        </div>
      </nav>
    );
  }
}

export default GuestHeader;
