import React, { Component } from "react";
import { Link } from "react-router-dom";

import axios from "axios";

import { CartConsumer } from "../../../Contexts/CartContext";

import AddToCartBtn from "../Partials/AddToCartBtn";
import HeaderFooter from "../Shared/HeaderFooter";

export default class Cart extends Component {
  state = {
    partNumber: "",
    descriptions: "",
    suggestions: [],
    quantity: 1,
    company: ""
  };

  render() {
    return (
      <HeaderFooter>
        <CartConsumer>
          {contextValue => {
            const { contextState, addToCart, changeQuantity } = contextValue;
            return (
              <React.Fragment>
                <h1 className="my-2">Your cart</h1>

                <table className="table table-striped">
                  <thead>
                    <tr className="row">
                      <th className="col-md-1" scope="col">
                        #
                      </th>
                      <th className="col-md-3" scope="col">
                        Part number
                      </th>
                      <th className="col-md-3" scope="col">
                        Descriptions
                      </th>
                      <th className="col-md-2" scope="col">
                        Quantity
                      </th>
                      <th className="col-md-3" scope="col">
                        Remove
                      </th>
                    </tr>
                  </thead>
                  <tbody>
                    {contextState.cartItems.map((item, index) => {
                      return this.renderCartLine(
                        item,
                        index + 1,
                        changeQuantity
                      );
                    })}
                  </tbody>
                </table>
                {this.renderForm(addToCart)}
                <div className="row mt-5">
                  <Link to="/guest/checkout">
                    <button className="btn btn-primary">Submit request</button>
                  </Link>
                </div>
              </React.Fragment>
            );
          }}
        </CartConsumer>
      </HeaderFooter>
    );
  }
  renderForm = addToCart => {
    return (
      <form
        autoComplete="off"
        onSubmit={event => {
          event.preventDefault();
          addToCart({
            partNumber: this.state.partNumber,
            descriptions: this.state.descriptions,
            quantity: this.state.quantity
          });
        }}
      >
        <div className="badge badge-dark p-2 mb-1">
          <span>Add new items to quotation request</span>
        </div>
        <div className="form-row align-items-center">
          <div className="col-auto dropdown">
            <label>PART NUMBER</label>
            <input
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              name="partNumber"
              value={this.state.partNumber}
              type="text"
              className="form-control mb-2 dropdown-toggle"
              placeholder="eg. 600-319-3240"
              onChange={this.onFormChange}
              required
            />
            <div
              className="dropdown-menu pre-scrollable"
              aria-labelledby="dropdownMenuButton"
            >
              {this.state.suggestions.length === 0 ? (
                <button className="dropdown-item">No match found</button>
              ) : (
                this.state.suggestions.map((item, index) => {
                  //iterate over suggestions and display
                  return (
                    <button
                      key={index}
                      className="dropdown-item"
                      onClick={event => {
                        //set the value from clicked suggestion to inputs
                        event.preventDefault();
                        this.setState({
                          partNumber: item.partNumber,
                          description: item.descriptions.map(
                            (description, index) =>
                              ` ${index > 0 ? " | " : ""}${
                                description.descriptionName
                              }  `
                          )
                        });
                      }}
                    >
                      {item.partNumber}
                    </button>
                  );
                })
              )}
            </div>
          </div>
          <div className="col-auto">
            <label>DESCRIPTION</label>
            <input
              name="descriptions"
              value={this.state.descriptions}
              type="text"
              className="form-control mb-2"
              placeholder="eg. Bolt shoe"
              onChange={this.onFormChange}
            />
          </div>
          <div className="col-auto">
            <label>QUANTITY</label>
            <input
              name="quantity"
              value={this.state.quantity}
              type="text"
              className="form-control mb-2"
              placeholder="Quantity"
              onChange={this.onFormChange}
              required
            />
          </div>
          <div className="col-auto mt-4">
            <button type="submit" className="btn btn-primary mb-2">
              Add
            </button>
          </div>
        </div>
      </form>
    );
  };

  onFormChange = event => {
    //handle change event from add item-line form
    let eventName = event.target.name;
    let eventValue = event.target.value;
    this.setState(
      {
        [eventName]: eventValue
      },
      () => {
        if (eventName === "partNumber") {
          if (eventValue.length === 0) {
            this.setState({
              descriptions: ""
            });
          }
          this.loadSuggestions();
        }
      }
    );
  };

  loadSuggestions = () => {
    //load suggestions from server and update component state
    axios
      .get(
        `/api/product/search?searchQuery=${
          this.state.partNumber //part number as search query
        }`
      )
      .then(response => {
        this.setState({
          suggestions: response.data
        });
      })
      .catch(error => {
        console.log("search error", error);
      });
  };

  renderCartLine = (cartItem, index, changeQuantity) => {
    return (
      <React.Fragment Key={index}>
        <tr className="row">
          <th className="col-md-1" scope="row">
            {index}
          </th>
          <td className="col-md-3">
            <Link to={`/guest/product/${cartItem.productId}`}>
              {cartItem.partNumber}
            </Link>{" "}
          </td>
          <td className="col-md-3">
            {cartItem.descriptions.map(
              (description, index) =>
                ` ${index > 0 ? " | " : ""}${description.descriptionName}  `
            )}
          </td>
          <td className="col-md-2">
            <input
              className="form-control mw-25"
              value={cartItem.quantity}
              type="number"
              placeholder={cartItem.quantity}
              onChange={event => {
                changeQuantity(cartItem, event.target.value);
              }}
            />
          </td>
          <td className="col-md-3">
            <AddToCartBtn product={cartItem} />
          </td>
        </tr>
      </React.Fragment>
    );
  };
}
