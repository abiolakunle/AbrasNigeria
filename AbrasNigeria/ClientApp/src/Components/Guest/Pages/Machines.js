import React, { Component } from "react";

import { Link } from "react-router-dom";

import axios from "axios";

import Pagination from "../Shared/Pagination";
import HeaderFooter from "../Shared/HeaderFooter";

export default class Machines extends Component {
  state = {
    machines: [],
    page: 1,
    paging: {},
    modelNameSuggestions: []
  };

  render() {
    return (
      <HeaderFooter>
        <React.Fragment>
          <h1 className="my-2">Machines</h1>
          <hr />
          {this.renderFilterForm()}
          <div className="row">
            {this.state.machines.map(machine => {
              return this.renderMachine(machine);
            })}
          </div>
          <Pagination paging={this.state.paging} querySender={this.sendQuery} />
        </React.Fragment>
      </HeaderFooter>
    );
  }

  componentDidMount() {
    this.sendQuery(this.page);
  }

  renderMachine(machine) {
    //renders list of machines
    return (
      <React.Fragment key={machine.modelName}>
        <div className="col-md-4 mb-3">
          <div className="card shadow-sm">
            <div className="card-body">
              <Link to={`/guest/machine/${machine.machineId}`}>
                <h5>
                  <span>{machine.brandName} </span>
                  {machine.modelName}
                </h5>
              </Link>
              <hr />
              <p className="mb-1 pb-1">
                <b>Serial number: </b> {machine.serialNumber}
              </p>
            </div>
            {/* @*
            <div className="card-footer">
              <a
                asp-controller="Description"
                asp-action="Update"
                asp-route-id="@description.DescriptionId"
                className="btn btn-dark col-md-3"
              >
                Edit
              </a>
              <a
                asp-controller="Description"
                asp-action="Delete"
                asp-route-id="@description.DescriptionId"
                className="btn btn-primary col-md-3"
              >
                Delete
              </a>
            </div>
            *@ */}
          </div>
        </div>
      </React.Fragment>
    );
  }

  sendQuery = page => {
    //sends search query to api and assigns data from response into state
    axios.get(`/api/machine/list?page=${page}`).then(response => {
      let paging = JSON.parse(response.headers.paging); //convert paging test to Json object

      this.setState({
        machines: response.data,
        paging,
        page
      });
    });
  };

  renderFilterForm() {
    //renders for filtering list of machines
    return (
      <React.Fragment>
        <div className="badge badge-dark p-2 mb-1">Search: </div>
        <form
          autoComplete="off"
          onSubmit={event => {
            event.preventDefault();
            this.sendQuery();
          }}
        >
          <div className="form-row mb-5">
            <label>MODEL NAME</label>
            <input
              id="dropdownMenuButton"
              className="form-control mb-2 mr-sm-2 dropdown-toggle"
              data-toggle="dropdown"
              aria-haspopup="true"
              placeholder="eg. D155A-5"
              name="modelName"
              value={this.state.modelName}
              type="text"
              onChange={this.onFormChanged}
            />
            <div
              className="dropdown-menu pre-scrollable"
              aria-labelledby="dropdownMenuButton"
            >
              {this.state.modelNameSuggestions.length === 0 ? (
                <button className="dropdown-item">No match found</button>
              ) : (
                this.state.modelNameSuggestions.map((item, index) => {
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
                          modelName: item.modelName
                        });
                      }}
                    >
                      {item.modelName}
                    </button>
                  );
                })
              )}
            </div>
            <button type="submit" className="btn btn-primary mb-2">
              Submit
            </button>
          </div>
        </form>
      </React.Fragment>
    );
  }

  onFormChanged = event => {
    //handles change event for filter form.
    let eventName = event.target.name;
    let eventValue = event.target.value;
    this.setState(
      {
        [eventName]: eventValue
      },
      () => {
        this.loadSuggestions();
      }
    );
  };

  loadSuggestions = () => {
    //load suggestions for form from server and update component state
    axios
      .get(
        `/api/machine/search?searchQuery=${
          this.state.modelName //part number as search query
        }`
      )
      .then(response => {
        this.setState({
          modelNameSuggestions: response.data
        });
      })
      .catch(error => {
        console.log("suggestion error", error);
      });
  };
}
