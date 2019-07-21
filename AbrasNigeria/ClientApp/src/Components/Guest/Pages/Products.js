import React, { Component } from "react";

import axios from "axios";

export default class products extends Component {
  state = {
    partNumber: "",
    category: "",
    section: "",
    sectionGroup: "",
    machine: "",
    filterResult: [],

    partNumberSuggestions: []
  };

  render() {
    return (
      <React.Fragment>
        <div class="my-2">
          <h1 class="my-2">Products</h1>
        </div>

        {this.renderForm()}
        {this.renderProductList()}
      </React.Fragment>
    );
  }

  onFormChanged = event => {
    let eventName = event.target.name;
    let eventValue = event.target.value;
    this.setState(
      {
        [eventName]: eventValue
      },
      () => {
        console.log(eventName, this.state.partNumber);
        this.loadSuggestions();
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
          partNumberSuggestions: response.data
        });
      })
      .catch(error => {
        console.log("axios error", error);
      });
  };

  sendQuery = event => {
    event.preventDefault();
    let apiUrl = "https://localhost:44343/api/product/filter";

    let data = { ...this.state };

    axios
      .post(apiUrl, { ...data })
      .then(response => {
        this.setState({
          filterResult: response.data
        });
      })
      .catch(error => {
        console.error(error);
      });
  };

  renderForm() {
    return (
      <form
        autoComplete="off"
        className="form-inline"
        onSubmit={this.sendQuery}
      >
        <label className="sr-only" for="inlineFormInputName2">
          Part Number
        </label>

        <input
          id="dropdownMenuButton"
          data-toggle="dropdown"
          aria-haspopup="true"
          name="partNumber"
          value={this.state.partNumber}
          type="text"
          className="form-control mb-2 mr-sm-2 dropdown-toggle"
          placeholder="Part number"
          onChange={this.onFormChanged}
        />
        <div
          class="dropdown-menu pre-scrollable"
          aria-labelledby="dropdownMenuButton"
        >
          {this.state.partNumberSuggestions.length === 0 ? (
            <button className="dropdown-item">No match found</button>
          ) : (
            this.state.partNumberSuggestions.map((item, index) => {
              //iterate over suggestions and display
              return (
                <button
                  key={index}
                  class="dropdown-item"
                  onClick={event => {
                    //set the value from clicked suggestion to inputs
                    event.preventDefault();
                    this.setState({
                      // partNumber: item.partNumber,
                      // description: item.category.categoryName
                    });
                  }}
                >
                  {item.partNumber}
                </button>
              );
            })
          )}
        </div>

        <label className="sr-only" for="category">
          Category
        </label>
        <input
          type="text"
          className="form-control mb-2 mr-sm-2"
          id="inlineFormInputName2"
          placeholder="Category"
          name="category"
          value={this.state.category}
          onChange={this.onFormChanged}
        />

        <label className="sr-only" for="section">
          Section
        </label>
        <input
          type="text"
          className="form-control mb-2 mr-sm-2"
          id="inlineFormInputName2"
          placeholder="Section"
          name="section"
          value={this.state.section}
          onChange={this.onFormChanged}
        />

        <label className="sr-only" for="sectiongroup">
          Section group
        </label>
        <input
          type="text"
          className="form-control mb-2 mr-sm-2"
          id="inlineFormInputName2"
          placeholder="Section group"
          name="sectionGroup"
          value={this.state.sectionGroup}
          onChange={this.onFormChanged}
        />

        <label className="sr-only" for="machine">
          machine
        </label>
        <input
          type="text"
          className="form-control mb-2 mr-sm-2"
          id="inlineFormInputName2"
          placeholder="Machine"
          name="machine"
          value={this.state.machine}
          onChange={this.onFormChanged}
        />

        <div className="form-check mb-2 mr-sm-2">
          <input
            className="form-check-input"
            type="checkbox"
            id="inlineFormCheck"
          />
          <label className="form-check-label" for="inlineFormCheck">
            Strict
          </label>
        </div>

        <button type="submit" className="btn btn-primary mb-2">
          Submit
        </button>
      </form>
    );
  }

  renderProductList = () => {
    return (
      <React.Fragment>
        <div class="row">
          {this.state.filterResult.map(product => {
            return (
              <div class="col-md-4 mb-3">
                <div class="card shadow-sm">
                  <div class="card-body">
                    <h5>
                      <span>Part number: </span>
                      {product.partNumber}
                    </h5>
                    <hr />
                    <p class="mb-1 pb-1">
                      <b>Category: </b> {product.category.categoryName}
                    </p>
                  </div>
                </div>
              </div>
            );
          })}
        </div>
      </React.Fragment>
    );
  };
}
