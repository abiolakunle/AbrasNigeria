import React, { Component } from "react";

import axios from "axios";

import Pagination from "../Shared/Pagination";

export default class products extends Component {
  state = {
    partNumber: "",
    category: "",
    section: "",
    sectionGroup: "",
    machine: "",
    products: [],
    page: 1,
    paging: {},
    partNumberSuggestions: []
  };

  componentDidMount() {
    this.sendQuery(this.state.page);
  }

  render() {
    return (
      <React.Fragment>
        <div className="my-2">
          <h1 className="my-2">Products</h1>
        </div>

        {this.renderForm()}
        {this.renderProductList()}
        <Pagination paging={this.state.paging} querySender={this.sendQuery} />
        {/* {this.renderPagination(this.state.paging, this.sendQuery)} */}
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

  sendQuery = page => {
    let apiUrl = "https://localhost:44343/api/product/filter";

    let { partNumber, category, section, sectionGroup, machine } = this.state;

    let queryData = {
      partNumber,
      category,
      section,
      sectionGroup,
      machine,
      page
    };

    console.log("req", queryData);

    axios
      .post(apiUrl, { ...queryData })
      .then(response => {
        let paging = JSON.parse(response.headers.paging);

        this.setState({
          ...this.state,
          products: response.data,
          paging
        });
      })
      .catch(error => {
        console.error(error);
      });
  };

  renderForm() {
    return (
      <React.Fragment>
        <div class="badge badge-dark p-2 mb-1">Filter products by: </div>
        <form
          autoComplete="off"
          className=" form-inline mb-5"
          onSubmit={event => {
            event.preventDefault();
            this.sendQuery();
          }}
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
            className="dropdown-menu pre-scrollable"
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
                    className="dropdown-item"
                    onClick={event => {
                      //set the value from clicked suggestion to inputs
                      event.preventDefault();
                      this.setState({
                        ...this.state,
                        partNumber: item.partNumber
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

          {/* <label className="sr-only" for="section">
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
          /> */}

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

          {/* <div className="form-check mb-2 mr-sm-2">
          <input
            className="form-check-input"
            type="checkbox"
            id="inlineFormCheck"
          />
          <label className="form-check-label" for="inlineFormCheck">
            Strict
          </label>
        </div> */}

          <button type="submit" className="btn btn-primary mb-2">
            Submit
          </button>
        </form>
      </React.Fragment>
    );
  }

  renderProductList = () => {
    return (
      <React.Fragment>
        <div className="row">
          {this.state.products.map(product => {
            return (
              <div className="col-md-4 mb-3">
                <div className="card shadow-sm">
                  <div className="card-body">
                    <h5>
                      <span>Part number: </span>
                      {product.partNumber}
                    </h5>
                    <hr />
                    <p className="mb-1 pb-1">
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
