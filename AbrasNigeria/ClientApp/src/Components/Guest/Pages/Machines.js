import React, { Component } from "react";

import { Link } from "react-router-dom";

import axios from "axios";

export default class Machines extends Component {
  state = {
    machines: []
  };

  render() {
    return (
      <React.Fragment>
        <h1 className="my-2">Machines</h1>
        <div className="row">
          {this.state.machines.map(machine => {
            return this.renderMachine(machine);
          })}
        </div>
      </React.Fragment>
    );
  }

  componentDidMount() {
    axios.get("https://localhost:44343/api/machine/list").then(response => {
      this.setState(
        {
          machines: response.data
        },
        () => {
          console.log(this.state.machines);
        }
      );
    });
  }

  renderMachine(machine) {
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
                asp-controller="Category"
                asp-action="Update"
                asp-route-id="@category.CategoryId"
                className="btn btn-dark col-md-3"
              >
                Edit
              </a>
              <a
                asp-controller="Category"
                asp-action="Delete"
                asp-route-id="@category.CategoryId"
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
}
