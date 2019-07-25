import React, { Component } from "react";
import { Link } from "react-router-dom";

import axios from "axios";

import Pagination from "../Shared/Pagination";

export default class products extends Component {
  state = {
    partNumber: "",
    category: "",
    section: "",
    sectionGroup: "",
    machine: "",
    brand: "",
    products: [],
    page: 1,
    paging: {},
    partNumberSuggestions: [],
    brandSuggestions: [],
    categorySuggestions: [],
    sectionSuggestions: [],
    sectionGroupSuggestions: []
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
        <hr />

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
        this.loadSuggestions(eventName);
      }
    );
  };

  loadSuggestions = eventName => {
    let productsUrl = `https://localhost:44343/api/product/search?searchQuery=${
      this.state.partNumber
    }`;

    let brandsUrl = `https://localhost:44343/api/brand/search?searchQuery=${
      this.state.brand
    }`;

    let categoriesUrl = `https://localhost:44343/api/category/search?searchQuery=${
      this.state.category
    }`;

    let sectionsUrl = `https://localhost:44343/api/section/search?searchQuery=${
      this.state.section
    }`;

    let sectionGroupsUrl = `https://localhost:44343/api/sectionGroup/search?searchQuery=${
      this.state.sectionGroup
    }`;

    const switchEvent = eventName => {
      //load suggestions from server and update component state
      switch (eventName) {
        case "partNumber":
          return axios.get(productsUrl).then(response => {
            this.setState({
              partNumberSuggestions: response.data
            });
          });
        case "brand":
          return axios.get(brandsUrl).then(response => {
            this.setState({
              brandSuggestions: response.data
            });
          });
        case "category":
          return axios.get(categoriesUrl).then(response => {
            this.setState({
              categorySuggestions: response.data
            });
          });
        case "section":
          return axios.get(sectionsUrl).then(response => {
            this.setState({
              sectionSuggestions: response.data
            });
          });
        case "sectionGroup":
          return axios.get(sectionGroupsUrl).then(response => {
            this.setState({
              sectionGroupSuggestions: response.data
            });
          });
        default:
      }
    };

    switchEvent(eventName).catch(error => {
      console.error("axios error", error);
    });
  };

  renderSuggestions = (suggestions, type) => {
    return (
      <React.Fragment>
        <div
          className="dropdown-menu pre-scrollable"
          aria-labelledby="dropdownMenuButton"
        >
          {suggestions.length === 0 ? (
            <button className="dropdown-item">{`No ${type.toLowerCase()} match`}</button>
          ) : (
            suggestions.map((item, index) => {
              //iterate over suggestions and display
              switch (type) {
                case "PART":
                  return (
                    <button
                      key={index}
                      className="dropdown-item"
                      onClick={() => {
                        //set the value from clicked suggestion to inputs
                        this.setState({
                          ...this.state,
                          partNumber: item.partNumber
                        });
                      }}
                    >
                      {item.partNumber}
                    </button>
                  );

                case "BRAND":
                  return (
                    <button
                      key={index}
                      className="dropdown-item"
                      onClick={() => {
                        //set the value from clicked suggestion to inputs
                        this.setState({
                          ...this.state,
                          brand: item.brandName
                        });
                      }}
                    >
                      {item.brandName}
                    </button>
                  );

                case "CATEGORY":
                  return (
                    <button
                      key={index}
                      className="dropdown-item"
                      onClick={() => {
                        //set the value from clicked suggestion to inputs
                        this.setState({
                          ...this.state,
                          category: item.categoryName
                        });
                      }}
                    >
                      {item.categoryName}
                    </button>
                  );

                case "SECTION":
                  return (
                    <button
                      key={index}
                      className="dropdown-item"
                      onClick={() => {
                        //set the value from clicked suggestion to inputs
                        this.setState({
                          ...this.state,
                          section: item.sectionName
                        });
                      }}
                    >
                      {item.sectionName}
                    </button>
                  );

                case "SECTIONGROUP":
                  return (
                    <button
                      key={index}
                      className="dropdown-item"
                      onClick={() => {
                        //set the value from clicked suggestion to inputs
                        this.setState({
                          ...this.state,
                          sectionGroup: item.sectionGroupName
                        });
                      }}
                    >
                      {item.sectionGroupName}
                    </button>
                  );

                default:
                  return <div />;
              }
            })
          )}
        </div>
      </React.Fragment>
    );
  };

  sendQuery = page => {
    let apiUrl = "https://localhost:44343/api/product/filter";

    let {
      partNumber,
      category,
      section,
      sectionGroup,
      machine,
      brand
    } = this.state;

    let queryData = {
      partNumber,
      category,
      section,
      sectionGroup,
      machine,
      brand,
      page
    };

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
          <div className="dropdown">
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
            <React.Fragment>
              {this.renderSuggestions(this.state.partNumberSuggestions, "PART")}
            </React.Fragment>
          </div>

          <div className="dropdown">
            <label className="sr-only" for="category">
              Category
            </label>
            <input
              type="text"
              placeholder="Category"
              name="category"
              value={this.state.category}
              onChange={this.onFormChanged}
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              className="form-control mb-2 mr-sm-2 dropdown-toggle"
            />
            <React.Fragment>
              {this.renderSuggestions(
                this.state.categorySuggestions,
                "CATEGORY"
              )}
            </React.Fragment>
          </div>

          <div className="dropdown">
            <label className="sr-only" for="section">
              Section
            </label>
            <input
              type="text"
              placeholder="Section"
              name="section"
              value={this.state.section}
              onChange={this.onFormChanged}
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              className="form-control mb-2 mr-sm-2 dropdown-toggle"
            />
            <React.Fragment>
              {this.renderSuggestions(this.state.sectionSuggestions, "SECTION")}
            </React.Fragment>
          </div>

          <div className="dropdown">
            <label className="sr-only" for="sectionGroup">
              sectionGroup
            </label>
            <input
              type="text"
              placeholder="sectionGroup"
              name="sectionGroup"
              value={this.state.sectionGroup}
              onChange={this.onFormChanged}
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              className="form-control mb-2 mr-sm-2 dropdown-toggle"
            />
            <React.Fragment>
              {this.renderSuggestions(
                this.state.sectionGroupSuggestions,
                "SECTIONGROUP"
              )}
            </React.Fragment>
          </div>

          <div className="dropdown">
            <label className="sr-only" for="brand">
              brand
            </label>
            <input
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              className="form-control mb-2 mr-sm-2 dropdown-toggle"
              type="text"
              placeholder="Brand"
              name="brand"
              value={this.state.brand}
              onChange={this.onFormChanged}
            />
            <React.Fragment>
              {this.renderSuggestions(this.state.brandSuggestions, "BRAND")}
            </React.Fragment>
          </div>

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
                    <Link to={`/guest/product/${product.productId}`}>
                      <h5>
                        <span>Part number: </span>
                        {product.partNumber}
                      </h5>
                    </Link>
                    <hr />
                    <p className="mb-1 pb-1">
                      <b>Category: </b> {product.category}
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
