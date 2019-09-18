import React, { Component } from "react";

import axios from "axios";

import { CartConsumer } from "../../../Contexts/CartContext";
import HeaderFooter from "../Shared/HeaderFooter";

export default class CheckOut extends Component {
  state = {
    companyName: "",
    address: "",
    state: "",
    city: "",
    cityState: "",
    email: "",
    phone: "",
    note: ""
  };

  render() {
    return (
      <HeaderFooter>
        <React.Fragment>
          <h1>Your details</h1>
          <p>
            Please enter your details and we will reply in less than 24Hours
          </p>
          <hr />
          <div className="form-group row">
            <label className="col-md-3">Name/Company name: </label>
            <input
              name="companyName"
              className="form-control col-md-7"
              type="text"
              value={this.state.companyName}
              onChange={this.onFormChange}
              required
            />
          </div>
          <div className="form-group row">
            <label className="col-md-3">Email: </label>
            <input
              name="email"
              className="form-control col-md-7"
              type="text"
              value={this.state.email}
              onChange={this.onFormChange}
              required
            />
          </div>

          <div className="form-group row">
            <label className="col-md-3">Phone number: </label>
            <input
              name="phoneNumber"
              className="form-control col-md-7"
              type="text"
              value={this.state.phoneNumber}
              onChange={this.onFormChange}
              required
            />
          </div>

          <div className="form-group row">
            <label className="col-md-3">Address: </label>
            <input
              name="address"
              className="form-control col-md-7"
              type="text"
              value={this.state.address}
              onChange={this.onFormChange}
            />
          </div>
          <div className="form-group row">
            <label className="col-md-3">City: </label>
            <input
              name="city"
              className="form-control col-md-7"
              type="text"
              value={this.state.city}
              onChange={this.onFormChange}
            />
          </div>
          <div className="form-group row">
            <label className="col-md-3">State: </label>
            <input
              name="cityState"
              className="form-control col-md-7"
              type="text"
              value={this.state.cityState}
              onChange={this.onFormChange}
              required
            />
          </div>
          <div className="form-group row">
            <label className="col-md-3">Notes & additional information: </label>
            <textarea
              name="note"
              className="form-control col-md-7"
              rows="6"
              value={this.state.note}
              onChange={this.onFormChange}
            />
          </div>
          <div className="form-group row">
            <div className="col-md-3" />
            <div className="col-md-7">
              <CartConsumer>
                {contextValue => {
                  let { cartItems } = contextValue.contextState;
                  return (
                    <button
                      className="btn btn-primary"
                      onClick={() => {
                        this.onSubmit(cartItems);
                      }}
                    >
                      Complete Request
                    </button>
                  );
                }}
              </CartConsumer>
            </div>
          </div>
        </React.Fragment>
      </HeaderFooter>
    );
  }

  onFormChange = event => {
    let eventName = event.target.name;
    let eventValue = event.target.value;

    this.setState({
      [eventName]: eventValue
    });
  };

  onSubmit = cartItems => {
    let apiUrl = "/order/addorder";

    let Order = {
      ...this.state,
      cartItems
    };

    axios
      .post(apiUrl, Order)
      .then(response => {
        console.log(response);
      })
      .catch(error => {
        console.error(error);
      });
  };
}
