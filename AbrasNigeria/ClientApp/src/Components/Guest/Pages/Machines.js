import React, { Component } from "react";

import axios from "axios";

export default class Machines extends Component {
  render() {
    return (
      <React.Fragment>
        <h1 class="my-2">Machines</h1>
      </React.Fragment>
    );
  }

  componentDidMount() {
    axios.get();
  }

  renderMachine() {
    return (
      <React.Fragment>
        <div class="col-md-4 mb-3">
          <div class="card shadow-sm">
            <div class="card-body">
              <a
                asp-controller="Machine"
                asp-action="Machine"
                asp-route-id="@machine.MachineId"
              >
                <h5>
                  <span>@machine.Brand.Name </span>@machine.ModelName
                </h5>
              </a>
              <hr />
              <p class="mb-1 pb-1">
                <b>Serial number: </b> @machine.SerialNumber
              </p>
            </div>
            @*
            <div class="card-footer">
              <a
                asp-controller="Category"
                asp-action="Update"
                asp-route-id="@category.CategoryId"
                class="btn btn-dark col-md-3"
              >
                Edit
              </a>
              <a
                asp-controller="Category"
                asp-action="Delete"
                asp-route-id="@category.CategoryId"
                class="btn btn-primary col-md-3"
              >
                Delete
              </a>
            </div>
            *@
          </div>
        </div>
      </React.Fragment>
    );
  }
}
