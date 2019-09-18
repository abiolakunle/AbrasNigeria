import React, { Component } from "react";
import axios from "axios";

import { authHeader } from "../../../Helpers/authHeader";

import { Link } from "react-router-dom";
import SideNavbar from "../Shared/SideNavbar";

class StockList extends Component {
  state = {
    stockProducts: []
  };

  componentDidMount() {
    this.loadStock();
  }

  render() {
    return (
      <SideNavbar>
        <React.Fragment>
          <h1 className="my-2">Stock</h1>
          <hr />

          <ul className="list-group">
            {this.state.stockProducts.map((stockProduct, index) => {
              const {
                stockProductId,
                partNumber,
                category,
                quantity
              } = stockProduct;
              console.log("stock", stockProduct);

              return (
                <React.Fragment key={index}>
                  <li className="list-group-item justify-content-between align-items-center">
                    <div className="row">
                      <div className="col-md-4">
                        <Link to={`/admin/stock/${stockProductId}`}>
                          <span className="font-weight-bold">PartNumber: </span>
                          {partNumber}
                        </Link>
                      </div>
                      <div className="col-md-4">
                        <span className="font-weight-bold">Category:</span>
                        {category}{" "}
                      </div>
                      <div className="col-md-4">
                        <span className="font-weight-bold">
                          Current quantity:
                        </span>
                        <span className="badge badge-primary badge-pill ml-2">
                          {quantity}
                        </span>
                      </div>
                    </div>
                  </li>
                </React.Fragment>
              );
            })}
          </ul>
        </React.Fragment>
      </SideNavbar>
    );
  }

  loadStock = () => {
    const api = "/api/stock/products";
    const requestOptions = {
      method: "POST",
      headers: { ...authHeader(), "Content-Type": "application/json" }
    };
    axios
      .get(api, requestOptions)
      .then(response => {
        console.log("data", response.data);
        this.setState({
          stockProducts: response.data
        });
      })
      .catch(error => {
        console.error(error);
      });
  };

  addHistory = id => {
    const api = "/api/stock/addHistory";
    const requestOptions = {
      method: "POST",
      headers: { ...authHeader(), "Content-Type": "application/json" }
    };

    const data = {
      stockProductId: id,
      addedQuantity: 1,
      note: "No note to display"
    };

    console.log("Sent", data);
    axios
      .post(api, { ...data }, requestOptions)
      .then(response => {
        this.setState({
          stockProducts: response.data
        });
      })
      .catch(error => {
        console.error(error);
      });
  };
}

export default StockList;
