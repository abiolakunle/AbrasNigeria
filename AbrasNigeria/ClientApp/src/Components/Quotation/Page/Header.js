import React from "react";
import { Link } from "react-router-dom";

import logo from "../../../Images/Abras logo 2.png";

const Header = ({ quoteNumber }) => {
  return (
    <React.Fragment>
      <div class="dropdown float-left">
        <button
          class="btn blue-grey lighten-5 "
          type="button"
          id="dropdownMenuButton"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        >
          <span className="fas fa-angle-down " />
        </button>
        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
          <Link to={`/send/${quoteNumber}`}>
            <div className="dropdown-item">
              <span class="far fa-envelope"> Send via mail</span>
            </div>
          </Link>
          <Link to="/quotations">
            <div className="dropdown-item">
              <span>Quotation list</span>
            </div>
          </Link>
          <Link to="/quotation/new">
            <div className="dropdown-item">
              <span>New quotation</span>
            </div>
          </Link>
        </div>
      </div>
      <div className="">
        <div className="container">
          <div className="d-flex justify-content-center mt-3">
            <img src={logo} width="120px" alt="abras" />
          </div>
          <h1 className="d-flex justify-content-center red-text display-5 indigo-text darken-3 text-uppercase font-weight-bolder my-0">
            Abras nigeria enterprises
          </h1>
          <p className="d-flex justify-content-center font-weight-bold mb-3">
            Suppliers of wide range of heavy duty equipment parts & maintenance
            services
          </p>
          <hr />
          <div className="row">
            <div className="col-md-6">
              <div className="row">
                <p className="mb-0">
                  <span className="font-weight-bold">Phone:</span> 08036775192,
                  08083458300
                </p>
              </div>

              <p className="row">
                <span className="font-weight-bold">Email:</span>
                {"  "}
                Abrasnigeriaent@gmail.com
              </p>
            </div>
            <div className="col-md-6">
              <div className="row">
                <div class="col-md-3 font-weight-bold">Addresses:</div>
                <div className="col-md-9">
                  <div className="row">
                    10, Ajiboye Street, Ketu, Alapere, Lagos.
                  </div>
                  <div className="row">
                    41 Ifeloju Street, Obada-Oko, Abeokuta
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Header;
