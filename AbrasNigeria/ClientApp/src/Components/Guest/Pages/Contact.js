import React, { Component } from "react";
import HeaderFooter from "../Shared/HeaderFooter";

export default class Contact extends Component {
  render() {
    return (
      <HeaderFooter>
        <React.Fragment>
          <div className="row">
            <div className="col">
              <div className="card">
                <div className="card-header">
                  <i className="fa fa-envelope" /> Contact us.
                </div>
                <div className="card-body">
                  <form>
                    <div className="form-group">
                      <label for="name">Name</label>
                      <input
                        type="text"
                        className="form-control"
                        id="name"
                        aria-describedby="emailHelp"
                        placeholder="Enter name"
                        required
                      />
                    </div>
                    <div className="form-group">
                      <label for="name">Company Name</label>
                      <input
                        type="text"
                        className="form-control"
                        id="company-name"
                        aria-describedby="emailHelp"
                        placeholder="Enter your company name"
                        required
                      />
                    </div>
                    <div className="form-group">
                      <label for="email">Email address</label>
                      <input
                        type="email"
                        className="form-control"
                        id="email"
                        aria-describedby="emailHelp"
                        placeholder="Enter email"
                        required
                      />
                      <small id="emailHelp" className="form-text text-muted">
                        We'll never share your email with anyone else.
                      </small>
                    </div>
                    <div className="form-group">
                      <label for="message">Message</label>
                      <textarea
                        className="form-control"
                        id="message"
                        rows="6"
                        required
                      />
                    </div>
                    <div className="mx-auto">
                      <button
                        type="submit"
                        className="btn btn-primary text-right"
                      >
                        Submit
                      </button>
                    </div>
                  </form>
                </div>
              </div>
            </div>
            <div className="col-12 col-sm-4">
              <div className="card bg-light mb-3">
                <div className="card-header text-uppercase">
                  <i className="fa fa-home" /> Address
                </div>
                <div className="card-body">
                  <div className="row">
                    <div className="col-md-auto font-weight-bold">
                      Addresses:
                    </div>
                    <div className="col-md-auto">
                      <p className="">
                        10, Ajiboye Street, Ketu, Alapere, Lagos.
                      </p>
                      <p className="">41 Ifeloju Street, Obada-Oko, Abeokuta</p>
                      <p>
                        <strong>Email: </strong>Abrasnigent@gmail.com
                      </p>
                      <p>
                        <strong>Tel: </strong> +234 810 652 9289
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </React.Fragment>
      </HeaderFooter>
    );
  }
}
