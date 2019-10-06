import React, { Component } from "react";

import SideNavbar from "../Shared/SideNavbar";
import axios from "axios";

import { authHeader } from "../../../Helpers/authHeader";

class StockProduct extends Component {
  state = {
    stockProductId: "",
    partNumber: "",
    brand: "",
    description: "",
    stockProductHistories: [],
    addedQuantity: "",
    removedQuantity: "",
    note: ""
  };

  componentDidMount() {
    this.loadProductHistory();
  }

  render() {
    const { partNumber, brand, description, stockProductHistories } = this.state;

    return (
      <SideNavbar>
        {
          <React.Fragment>
            <h1 className="my-2">
              {brand} - {partNumber} - {description}
            </h1>
            <hr />
            {this.renderAddHistory()}
            <ul className="list-group">
              {stockProductHistories.map((productHistory, index) => {
                const {
                  addedQuantity,
                  removedQuantity,
                  date,
                  note
                } = productHistory;

                return (
                  <React.Fragment key={index}>
                    <li className="list-group-item justify-content-between align-items-center">
                      <div className="row">
                        <div className="col-md-3">
                          <span className="font-weight-bold">Date: </span>
                          <span className="">
                            {new Date(date).toDateString()}
                          </span>
                        </div>
                        <div className="col-md-3">
                          <span className="font-weight-bold">
                            Added Quantity:{" "}
                          </span>
                          <span className="badge badge-primary badge-pill">
                            {addedQuantity}
                          </span>
                        </div>
                        <div className="col-md-3">
                          <span className="font-weight-bold">
                            Removed Quantity:{" "}
                          </span>
                          <span className="badge badge-primary badge-pill">
                            {removedQuantity}
                          </span>
                        </div>
                        <div className="col-md-3">
                          <span className="font-weight-bold">Note: </span>
                          <span className="">{note}</span>
                        </div>
                      </div>
                    </li>
                  </React.Fragment>
                );
              })}
            </ul>
          </React.Fragment>
        }
      </SideNavbar>
    );
  }

  handleChange = event => {
    const { name, value } = event.target;

    this.setState(
      {
        [name]: value
      },
      () => {
        if (name === "removedQuantity") {
          if (this.state.addedQuantity.length > 0) {
            this.setState({
              addedQuantity: ""
            });
          }
        } else if (name === "addedQuantity") {
          if (this.state.removedQuantity.length > 0) {
            this.setState({
              removedQuantity: ""
            });
          }
        }
      }
    );
  };

  handleSubmit = event => {
    event.preventDefault();

    const api = "/api/stock/addhistory/";

    const requestOptions = {
      method: "POST",
      headers: { ...authHeader(), "Content-Type": "application/json" }
    };

    let { stockProductId, addedQuantity, removedQuantity, note } = this.state;
    addedQuantity = Number(addedQuantity);
    removedQuantity = Number(removedQuantity);
    const data = { stockProductId, addedQuantity, removedQuantity, note };
    console.log("data", data);
    axios
      .post(api, data, requestOptions)
      .then(response => {
        this.loadProductHistory();
      })
      .catch(error => {
        console.log(error);
      });
  };

  loadProductHistory = () => {
    const id = this.props.match.params.id;

    const api = `/api/stock/product?=${id}`;

    const requestOptions = {
      method: "POST",
      headers: { ...authHeader(), "Content-Type": "application/json" }
    };

    axios
      .get(api, requestOptions)
      .then(({ data }) => {
        const {
          stockProductId,
          partNumber,
          brand,
          description,
          stockProductHistories
        } = data;
        this.setState({
          stockProductId,
          partNumber,
          brand,
          description,
          stockProductHistories
        });
      })
      .catch(error => {
        console.error(error);
      });
  };

  renderAddHistory = () => {
    const { addedQuantity, removedQuantity, note } = this.state;
    return (
      <React.Fragment>
        <div className="badge badge-dark p-2 mb-1">Update stock: </div>
        <form onSubmit={this.handleSubmit}>
          <div className="form-row align-items-center">
            <div className="col-auto">
              <label className="sr-only" for="inlineFormInput">
                Add Quantity
              </label>
              <input
                type="number"
                name="addedQuantity"
                value={addedQuantity}
                className="form-control mb-2"
                placeholder="Add Quantity"
                onChange={this.handleChange}
              />
            </div>

            <div className="col-auto">
              <label className="sr-only" for="inlineFormInput">
                Remove Quantity
              </label>
              <input
                type="number"
                name="removedQuantity"
                value={removedQuantity}
                className="form-control mb-2"
                placeholder="Remove Quantity"
                onChange={this.handleChange}
              />
            </div>
            <div className="col-auto">
              <label className="sr-only" for="inlineFormInput">
                Note
              </label>
              <input
                type="text"
                name="note"
                value={note}
                className="form-control mb-2"
                placeholder="Note"
                onChange={this.handleChange}
              />
            </div>

            <div className="col-auto">
              <button type="submit" className="btn btn-primary mb-2">
                Submit
              </button>
            </div>
          </div>
        </form>
      </React.Fragment>
    );
  };
}

export default StockProduct;
