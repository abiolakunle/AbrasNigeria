import React, { Component } from "react";

import { DocumentConsumer } from "../../../Contexts/DocumentContext";

class Info extends Component {
  state = {
    company: "",
    docType: "Quotation",
    date: new Date().toISOString().split("T")[0]
    //`${new Date().getFullYear()}-${new Date().getMonth()}-${new Date().getDate()}`
  };

  onFormChange = (dispatch, event) => {
    this.setState(
      {
        [event.target.name]: event.target.value
      },
      () => {
        dispatch({
          type: "INFO",
          payload: this.state
        });
      }
    );
  };

  render() {
    return (
      <DocumentConsumer>
        {contextValue => {
          const { contextState } = contextValue;
          return (
            <React.Fragment>
              <div>{this.renderForm(contextState.dispatch)}</div>
            </React.Fragment>
          );
        }}
      </DocumentConsumer>
    );
  }

  renderForm(dispatch) {
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
                onChange={this.onFormChange.bind(this, dispatch)}
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
                name="docType"
                value={this.state.docType}
                onChange={this.onFormChange.bind(this, dispatch)}
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
                onChange={this.onFormChange.bind(this, dispatch)}
                className="form-control"
              />
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default Info;
