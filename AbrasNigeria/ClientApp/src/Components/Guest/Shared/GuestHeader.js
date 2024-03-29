import React, { Component } from "react";
import { NavLink } from "react-router-dom";

import AbrasLogo from "../../../Images/abrasLogo.png";

import { CartConsumer } from "../../../Contexts/CartContext";

class GuestHeader extends Component {
  render() {
    return (
      <CartConsumer>
        {contextValue => {
          const { contextState } = contextValue;
          return (
            <React.Fragment>
              <header>
                <nav className="navbar navbar-dark bg-dark p-1">
                  <div className="ml-auto badge badge-light mx-1">
                    Call <a href="tel:+234 810 652 9288"> +234 810 652 9288</a>
                  </div>
                  <div className="badge badge-light mx-1">
                    Email{" "}
                    <a href="mailto:Abrasnigent@gmail.com">
                      abrasnigeriaent@gmail.com
                    </a>
                  </div>
                </nav>
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

                  <div
                    className="collapse navbar-collapse"
                    id="navbarSupportedContent"
                  >
                    <ul className="navbar-nav ml-auto">
                      <li className="nav-item ">
                        <NavLink to="/guest/home" active ClassName="active">
                          <div className="nav-link">
                            Home <span className="sr-only">(current)</span>
                          </div>
                        </NavLink>
                      </li>
                      <li className="nav-item ">
                        <NavLink
                          exact
                          to="/guest/products"
                          active
                          ClassName="active"
                        >
                          <div className="nav-link">
                            Products <span className="sr-only">(current)</span>
                          </div>
                        </NavLink>
                      </li>
                      <li className="nav-item ">
                        <NavLink
                          exact
                          to="/guest/categories"
                          activeClassName="active"
                        >
                          <div className="nav-link">
                            Categories{" "}
                            <span className="sr-only">(current)</span>
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
                        <NavLink to="/quotations" activeClassName="active">
                          <div className="nav-link">
                            Admin <span className="sr-only">(current)</span>
                          </div>
                        </NavLink>
                      </li>
                      <li className="nav-item ">
                        <NavLink to="/guest/contact" activeClassName="active">
                          <div className="nav-link">
                            Contact us{" "}
                            <span className="sr-only">(current)</span>
                          </div>
                        </NavLink>
                      </li>
                      <li className="nav-item ">
                        <NavLink to="/guest/cart" activeClassName="active">
                          <div className="nav-link btn btn-light">
                            Cart <span className="sr-only">(current)</span>{" "}
                            <span className="fas fa-shopping-cart text-dark" />
                            <span className="badge badge-dark">
                              {contextState.cartItems.length}
                            </span>
                          </div>
                        </NavLink>
                      </li>
                    </ul>
                    {/* <form className="form-inline my-2 my-lg-0">
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
            </form> */}
                  </div>
                </nav>
              </header>
            </React.Fragment>
          );
        }}
      </CartConsumer>
    );
  }
}

export default GuestHeader;
