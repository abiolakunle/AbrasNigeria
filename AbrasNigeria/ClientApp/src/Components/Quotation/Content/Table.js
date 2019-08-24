import React, { Component } from "react";

import axios from "axios";

import TableItem from "./TableItem";
import Summary from "./Summary";
import { DocumentConsumer } from "../../../Contexts/DocumentContext";

class Table extends Component {
  state = {
    partNumber: "",
    suggestions: [],
    description: "",
    quantity: undefined,
    unitPrice: undefined,
    extendedPrice: undefined,
    newItem: {},
    items: [],
    total: 0
  };

  render() {
    return (
      <DocumentConsumer>
        {contextValue => {
          const { contextState, sendInvoice } = contextValue;
          return (
            <React.Fragment>
              <table className="table table-striped">
                {this.renderTableHead()}
                <tbody>
                  {this.state.items.map((item, index) => {
                    return <TableItem key={index} index={index} item={item} />;
                  })}
                  <tr>
                    <td colSpan="100%">{this.renderForm(contextState)}</td>
                  </tr>
                </tbody>
                <tfoot>
                  <tr>
                    <td />
                    <td />
                    <td />
                    <td />
                    <td />
                    <td className="bg-secondary text-white">
                      <strong>{this.state.total.toLocaleString()}</strong>
                    </td>
                  </tr>
                </tfoot>
              </table>

              <Summary />
              <div className="row my-5">
                <div className="btn-group col-md-12">
                  <div className="btn btn-light col-md-6">Back</div>
                  <div
                    className="btn btn-primary col-md-6"
                    onClick={sendInvoice} //fire sendInvoice function from context state
                  >
                    Create
                  </div>
                </div>
              </div>
            </React.Fragment>
          );
        }}
      </DocumentConsumer>
    );
  }

  onSubmit = (contextState, event) => {
    event.preventDefault(); //prevent default behaviour of event
    this.setState(
      Object.assign(this.state.newItem, {
        partNumber: this.state.partNumber,
        description: this.state.description,
        quantity: this.state.quantity,
        unitPrice: this.state.unitPrice,
        extendedPrice: this.state.quantity * this.state.unitPrice
      })
    );

    this.addItem(contextState);
  };

  addItem = contextState => {
    let tempItems = [...this.state.items]; //spread items in state to temporary array
    tempItems.push({ ...this.state.newItem }); //spread new item into temporary array

    this.setState(
      { items: tempItems, total: this.calculateTotal(tempItems) },

      //callback function after state changes & send table data to context
      () => {
        const itemsAndTotal = Object.assign(
          {},
          {
            items: this.state.items,
            total: this.calculateTotal(tempItems)
          }
        );

        //send
        contextState.dispatch({
          type: "TABLE_DATA",
          payload: itemsAndTotal
        });
      }
    );
  };

  calculateTotal = itemsIn => {
    //calculate grand total of extended prices and set total in component state
    var total = 0;
    itemsIn.forEach(item => {
      total = total + item.extendedPrice;
    });

    this.setState({
      total: total
    });
    return total;
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
              description: ""
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
        `/api/product/search?searchQuery=${
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

  renderForm(contextState) {
    //renders for adding items line to table
    return (
      <React.Fragment>
        <form
          autoComplete="off"
          onSubmit={this.onSubmit.bind(this, contextState)}
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
                            description: item.category
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
                name="description"
                value={this.state.description}
                type="text"
                className="form-control mb-2"
                placeholder="Description"
                onChange={this.onFormChange}
              />
            </div>

            <div className="col-md-2">
              <input
                name="quantity"
                value={this.state.quantity}
                type="number"
                className="form-control mb-2"
                placeholder="Quantity"
                step="1"
                onChange={this.onFormChange}
              />
            </div>

            <div className="col-md-2">
              <input
                name="unitPrice"
                value={this.state.unitPrice}
                type="number"
                className="form-control mb-2"
                placeholder="Unit price"
                onChange={this.onFormChange}
              />
            </div>
            <div className="col-md-2">
              <input
                name="extendedPrice"
                value={this.state.unitPrice * this.state.quantity}
                type="number"
                className="form-control mb-2"
                placeholder="Extended price"
                readOnly
              />
            </div>

            <div className="col-auto">
              <button type="submit" className="btn btn-primary mb-2">
                Add
              </button>
            </div>
          </div>
        </form>
      </React.Fragment>
    );
  }

  renderTableHead() {
    return (
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Part Number</th>
          <th scope="col">Description</th>
          <th scope="col">Quantity</th>
          <th scope="col">Unit Price</th>
          <th scope="col">Extended Price</th>
        </tr>
      </thead>
    );
  }
}

export default Table;
