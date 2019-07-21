import React, { Component } from "react";

export default class Contact extends Component {
  render() {
    return (
      <React.Fragment>
        <div class="row">
          <div class="col">
            <div class="card">
              <div class="card-header">
                <i class="fa fa-envelope" /> Contact us.
              </div>
              <div class="card-body">
                <form>
                  <div class="form-group">
                    <label for="name">Name</label>
                    <input
                      type="text"
                      class="form-control"
                      id="name"
                      aria-describedby="emailHelp"
                      placeholder="Enter name"
                      required
                    />
                  </div>
                  <div class="form-group">
                    <label for="name">Company Name</label>
                    <input
                      type="text"
                      class="form-control"
                      id="company-name"
                      aria-describedby="emailHelp"
                      placeholder="Enter your company name"
                      required
                    />
                  </div>
                  <div class="form-group">
                    <label for="email">Email address</label>
                    <input
                      type="email"
                      class="form-control"
                      id="email"
                      aria-describedby="emailHelp"
                      placeholder="Enter email"
                      required
                    />
                    <small id="emailHelp" class="form-text text-muted">
                      We'll never share your email with anyone else.
                    </small>
                  </div>
                  <div class="form-group">
                    <label for="message">Message</label>
                    <textarea
                      class="form-control"
                      id="message"
                      rows="6"
                      required
                    />
                  </div>
                  <div class="mx-auto">
                    <button type="submit" class="btn btn-primary text-right">
                      Submit
                    </button>
                  </div>
                </form>
              </div>
            </div>
          </div>
          <div class="col-12 col-sm-4">
            <div class="card bg-light mb-3">
              <div class="card-header text-uppercase">
                <i class="fa fa-home" /> Address
              </div>
              <div class="card-body">
                <div className="row">
                  <div class="col-md-auto font-weight-bold">Addresses:</div>
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
    );
  }
}
