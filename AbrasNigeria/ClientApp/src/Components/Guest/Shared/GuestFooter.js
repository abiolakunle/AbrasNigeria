import React, { Component } from "react";

import { Link } from "react-router-dom";

class GuestFooter extends Component {
  render() {
    return (
      <footer className="text-light mt-5">
        <div className="container-fluid bg-dark pt-5">
          <div className="row">
            <div className="col-md-3 col-lg-4 col-xl-3">
              <h5>About</h5>
              <hr className="bg-white mb-2 mt-0 d-inline-block mx-auto w-25" />
              <p className="mb-0">
                Suppliers of komatsu, perkins, cat, volvo & cummins spare parts.
                <br />
                Dealers of forlift/other machine tyres and rim of different size
              </p>
            </div>
            {/* @*<div className="col-md-2 col-lg-2 col-xl-2 mx-auto">
                    <h5>Informations</h5>
                    <hr className="bg-white mb-2 mt-0 d-inline-block mx-auto w-25">
                    <ul className="list-unstyled">
                        <li><a href="">Link 1</a></li>
                        <li><a href="">Link 2</a></li>
                        <li><a href="">Link 3</a></li>
                        <li><a href="">Link 4</a></li>
                    </ul>
                </div>
                <div className="col-md-3 col-lg-2 col-xl-2 mx-auto">
                    <h5>Others links</h5>
                    <hr className="bg-white mb-2 mt-0 d-inline-block mx-auto w-25">
                    <ul className="list-unstyled">
                        <li><a href="">Link 1</a></li>
                        <li><a href="">Link 2</a></li>
                        <li><a href="">Link 3</a></li>
                        <li><a href="">Link 4</a></li>
                    </ul>
                </div>*@ */}
            <div className="col-md-4 col-lg-3 col-xl-3">
              <h5>Contact</h5>
              <hr className="bg-white mb-2 mt-0 d-inline-block mx-auto w-25" />
              <ul className="list-unstyled">
                <li>
                  <i className="fa fa-home mr-2" /> Abras Ngeria Enterprise
                </li>
                <li>
                  <i className="fa fa-envelope mr-2" />
                  <a href="mailto:Abrasnigent@gmail.com">
                    Abrasnigent@gmail.com
                  </a>
                </li>
                <li>
                  <i className="fa fa-phone mr-2" /> +234 810 652 9289
                </li>
              </ul>
            </div>
            <div className="col-12 copyright mt-3">
              <p className="float-left">
                <Link to="#">Back to top</Link>
              </p>
            </div>
          </div>
        </div>
      </footer>
    );
  }
}

export default GuestFooter;
