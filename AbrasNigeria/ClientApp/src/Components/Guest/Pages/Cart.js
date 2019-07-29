import React, { Component } from "react";

import axios from "axios";

import { CartConsumer } from "../../../Contexts/CartContext";

import AddToCartBtn from "../Partials/AddToCartBtn";

export default class Cart extends Component {
  state = {
    partNumber: "",
    category: "",
    suggestions: [],
    quantity: 1
  };

  render() {
    return (
      <CartConsumer>
        {contextValue => {
          const { contextState, addToCart, changeQuantity } = contextValue;
          return (
            <React.Fragment>
              <h1 className="my-2">Your cart</h1>

              <table class="table table-striped">
                <thead>
                  <tr className="row">
                    <th className="col-md-1" scope="col">
                      #
                    </th>
                    <th className="col-md-3" scope="col">
                      Part number
                    </th>
                    <th className="col-md-3" scope="col">
                      Category
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
                    return this.renderCartLine(item, index + 1, changeQuantity);
                  })}
                </tbody>
              </table>
              {this.renderForm(addToCart)}
            </React.Fragment>
          );
        }}
      </CartConsumer>
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
            category: this.state.category,
            quantity: this.state.quantity
          });
        }}
      >
        <div className="form-row align-items-center">
          <div className="col-auto dropdown">
            <input
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              name="partNumber"
              value={this.state.partNumber}
              type="text"
              className="form-control mb-2 dropdown-toggle"
              placeholder="Part number"
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
                          category: item.category
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
            <input
              name="category"
              value={this.state.category}
              type="text"
              className="form-control mb-2"
              placeholder="Description"
              onChange={this.onFormChange}
            />
          </div>
          <div className="col-auto">
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
          <div className="col-auto">
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
    var eventName = event.target.name;
    var eventValue = event.target.value;
    this.setState(
      {
        [eventName]: eventValue
      },
      () => {
        if (eventName === "partNumber") {
          if (eventValue.length === 0) {
            this.setState({
              category: ""
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
        `https://localhost:44343/api/product/search?searchQuery=${
          this.state.partNumber //part number as search query
        }`
      )
      .then(response => {
        this.setState({
          suggestions: response.data
        });
      })
      .catch(error => {
        console.log("axios error", error);
      });
  };

  renderCartLine = (cartItem, index, changeQuantity) => {
    return (
      <React.Fragment>
        <tr className="row" Key={index}>
          <th className="col-md-1" scope="row">
            {index}
          </th>
          <td className="col-md-3">{cartItem.partNumber}</td>
          <td className="col-md-3">{cartItem.category}</td>
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
