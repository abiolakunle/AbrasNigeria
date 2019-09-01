import React, { Component } from "react";
import { connect } from "react-redux";
import { Redirect, withRouter } from "react-router-dom";
import LoadingOverlay from "react-loading-overlay";
import NumInWords from "../../../Utils/NumInWords";

import {
  suggestPartNumber,
  clearPartNumberSuggestion
} from "../../../Actions/suggestionActions";
import { createDocument } from "../../../Actions/documentActions";

import DasboardIndex from "../Shared/AdminNav";

class NewDocument extends Component {
  state = {
    company: "",
    documentType: "Quotation",
    date: new Date().toISOString().split("T")[0],
    //`${new Date().getFullYear()}-${new Date().getMonth()}-${new Date().getDate()}`

    partNumber: "",
    description: "",
    quantity: undefined,
    unitPrice: undefined,
    extendedPrice: undefined,
    table: [],
    total: 0,

    note: ""
  };

  render() {
    const { isCreated, isCreating } = this.props;
    if (isCreated === true) {
      this.props.history.push("/admin/document/list");
    }

    return (
      <React.Fragment>
        <LoadingOverlay active={isCreating} spinner text="Creating document">
          <DasboardIndex>
            {this.renderInfoForm()}
            {this.renderTable()}
            {this.renderSummary()}
          </DasboardIndex>
        </LoadingOverlay>
      </React.Fragment>
    );
  }

  handleChange = event => {
    //handle change event from add item-line form
    const eventName = event.target.name;
    const eventValue = event.target.value;

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
          this.props.suggestPartNumber(eventValue);
        }
      }
    );
  };

  handleAddRow = event => {
    event.preventDefault();
    const { partNumber, description, quantity, unitPrice } = this.state;
    const newRow = { partNumber, description, quantity, unitPrice };
    const table = [...this.state.table, newRow];

    this.props.clearPartNumberSuggestion();
    this.setState(
      {
        table
      },
      () => {
        this.setState({
          partNumber: "",
          description: "",
          unitPrice: "",
          quantity: ""
        });

        this.calculateTotal(table);
      }
    );
  };

  calculateTotal = table => {
    //calculate grand total of extended prices and set total in component state
    let total = 0;
    table.forEach(item => {
      total += item.unitPrice * item.quantity;
    });

    this.setState({
      total
    });
  };

  prepareDocument = () => {
    let { company, documentType, date, table, note } = this.state;
    this.props.createDocument({
      company,
      documentType,
      date,
      table,
      note
    });
  };

  renderInfoForm = () => {
    return (
      <div className="row">
        <div className="col-md-6">
          <div className="form-group row">
            <label className="col-md-2">To:</label>
            <div className="col-md-9">
              <input
                type="text"
                name="company"
                value={this.state.company}
                onChange={this.handleChange}
                className="form-control"
              />
            </div>
          </div>
        </div>
        <div className="col-md-6">
          <div className="form-group row">
            <label className="col-md-3">Document Type: </label>
            <div className="col-md-9">
              <select
                type="text"
                name="documentType"
                value={this.state.documentType}
                onChange={this.handleChange}
                className="form-control"
              >
                <option value="Quotation">Quotation</option>
                <option value="Invoice">Invoice</option>
                <option value="Waybill">Waybill</option>
              </select>
            </div>
          </div>
          <div className="form-group row">
            <label className="col-md-3">Date: </label>
            <div className="col-md-9">
              <input
                type="date"
                name="date"
                value={this.state.date}
                onChange={this.handleChange}
                className="form-control"
              />
            </div>
          </div>
        </div>
      </div>
    );
  };

  renderTable = () => {
    return (
      <React.Fragment>
        <table className="table table-striped">
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
          <tbody>
            {this.state.table.map((item, index) => {
              return (
                <tr key={index}>
                  <th scope="row">{index + 1}</th>
                  <td>{item.partNumber}</td>
                  <td>{item.description}</td>
                  <td>{(item.quantity * 1).toLocaleString()}</td>
                  <td>{(item.unitPrice * 1).toLocaleString()}</td>
                  <td>{(item.unitPrice * item.quantity).toLocaleString()}</td>
                </tr>
              );
            })}
            <tr>
              <td colSpan="100%">{this.renderAddItem()}</td>
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
      </React.Fragment>
    );
  };

  renderAddItem = () => {
    return (
      <React.Fragment>
        <form autoComplete="off" onSubmit={this.handleAddRow}>
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
                onChange={this.handleChange}
              />
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
                onChange={this.handleChange}
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
                onChange={this.handleChange}
              />
            </div>

            <div className="col-md-2">
              <input
                name="unitPrice"
                value={this.state.unitPrice}
                type="number"
                className="form-control mb-2"
                placeholder="Unit price"
                onChange={this.handleChange}
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
  };

  renderSummary = () => {
    return (
      <React.Fragment>
        {this.state.total !== 0 ? (
          <div className="row my-5 text-primary">
            <div className="col-md-4 blue darken-4 font-weight-bold py-2">
              Amount in words:{" "}
            </div>
            <div className="col-md-8 blue darken-2 py-2">
              {NumInWords(this.state.total)} Naira only
            </div>
          </div>
        ) : (
          <div />
        )}
        <div className="row">
          <div className="col-md-6">
            <textarea
              className="form-control float-left my-3"
              rows="6"
              name="note"
              placeholder="Note and addtional information"
              value={this.state.note}
              onChange={this.handleChange}
            />
          </div>
        </div>
        <div className="row my-5">
          <div className="btn-group col-md-12">
            <div className="btn btn-light col-md-6">Clear</div>
            <div
              className="btn btn-primary col-md-6"
              onClick={this.prepareDocument} //fire sendInvoice function from context state
            >
              Create
            </div>
          </div>
        </div>
      </React.Fragment>
    );
  };
}

const mapStateToProps = state => {
  console.log(state);
  const { suggestionReducer, documentReducer } = state;
  return {
    partNoSuggestions: suggestionReducer.partNoSuggestions,
    isCreated: documentReducer.isCreated,
    isCreating: documentReducer.isCreating,
    error: documentReducer.error
  };
};

const mapDispatchToProps = dispatch => {
  return {
    suggestPartNumber: value => dispatch(suggestPartNumber(value)),
    clearPartNumberSuggestion: () => dispatch(clearPartNumberSuggestion()),
    createDocument: document => dispatch(createDocument(document))
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(withRouter(NewDocument));
