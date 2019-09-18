import React, { Component } from "react";
import { connect } from "react-redux";
import {
  suggestPartNumber,
  clearPartNumberSuggestion
} from "../../../Actions/suggestionActions";
import { authHeader } from "../../../Helpers/authHeader";

import axios from "axios";

import SideNavbar from "../Shared/SideNavbar";

class CreateStockProduct extends Component {
  state = {
    partNumber: "",
    category: "",
    brand: ""
  };
  render() {
    const { partNumber, category, brand } = this.state;
    return (
      <SideNavbar>
        <React.Fragment>
          <h1>Add Product to stock</h1>
          <form autoComplete="off" onSubmit={this.handleSubmit} className="">
            <div className="form-group">
              <input
                id="dropdownMenuButton"
                data-toggle="dropdown"
                aria-haspopup="true"
                type="text"
                className="form-control"
                placeholder="Part number"
                name="partNumber"
                value={partNumber}
                onChange={this.handleChange}
                required
              ></input>
              <div
                className="dropdown-menu pre-scrollable"
                aria-labelledby="dropdownMenuButton"
              >
                {this.props.partNoSuggestions.length === 0 ? (
                  <button className="dropdown-item">No match found</button>
                ) : (
                  this.props.partNoSuggestions.map((item, index) => {
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
                            category: item.category,
                            brand: item.brand
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
            <div className="form-group">
              <input
                type="text"
                className="form-control"
                placeholder="category"
                name="category"
                value={category}
                onChange={this.handleChange}
                required
              />
            </div>
            <div className="form-group">
              <input
                type="text"
                className="form-control"
                placeholder="Brand"
                name="brand"
                value={brand}
                onChange={this.handleChange}
                required
              />
            </div>

            <button type="submit" className="btn-primary btn">
              Create product
            </button>
          </form>
        </React.Fragment>
      </SideNavbar>
    );
  }

  sendStockProduct = () => {
    const { partNumber, category, brand } = this.state;
    const product = { partNumber, category, brand };

    const requestOptions = {
      method: "POST",
      headers: { ...authHeader(), "Content-Type": "application/json" }
    };

    axios
      .post("/api/stock/createproduct/", product, requestOptions)
      .then(response => {})
      .catch(error => {
        console.error(error);
      });
  };

  handleSubmit = event => {
    event.preventDefault();
    this.sendStockProduct();
  };

  handleChange = event => {
    const { name, value } = event.target;

    this.setState(
      {
        [name]: value
      },
      () => {
        if (name === "partNumber") {
          if (value.length === 0) {
            this.props.clearPartNumberSuggestion();
            this.setState({
              category: ""
            });
          }
          this.props.suggestPartNumber(value);
        }
      }
    );
  };
}

const mapStateToProps = ({ suggestionReducer }) => {
  return {
    partNoSuggestions: suggestionReducer.partNoSuggestions
  };
};

const mapDispatchToProps = dispatch => {
  return {
    suggestPartNumber: input => dispatch(suggestPartNumber(input)),
    clearPartNumberSuggestion: () => dispatch(clearPartNumberSuggestion())
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(CreateStockProduct);
