import React, { Component } from "react";

import { Link } from "react-router-dom";

import axios from "axios";

class QuotationList extends Component {
  state = {
    quotations: []
  };
  render() {
    let quotationListItem = this.state.quotations.map(quotation => {
      return (
        <React.Fragment>
          <li
            key={quotation.quotationId}
            className="list-group-item  justify-content-between align-items-center"
          >
            <div className="row">
              <Link to={`/view/${quotation.quotationId}`}>
                <div className="col-md-4">
                  <span className="font-weight-bold">Quote Number: </span>
                  {quotation.quoteNo}
                </div>
              </Link>
              <div className="col-md-3">
                <span className="font-weight-bold">Company: </span>
                {quotation.company}
              </div>
              <div className="col-md-3">
                <span className="font-weight-bold">Date: </span>
                {new Date(quotation.date).toDateString()}
              </div>
              <div className="col-md-2">
                <span className="badge badge-primary badge-pill">
                  {quotation.table.length}
                </span>
              </div>
            </div>
          </li>
        </React.Fragment>
      );
    });
    return (
      <React.Fragment>
        <Link to="/quotation">
          <button className="btn btn-primary my-2 ml-5">New Invoice</button>
        </Link>
        <ul className="list-group">{quotationListItem}</ul>
      </React.Fragment>
    );
  }

  componentDidMount() {
    this.getQuotations();
  }

  getQuotations() {
    axios
      .get("https://localhost:44343/api/Quotation")
      .then(response => {
        this.setState(
          {
            quotations: response.data
          },
          () => {
            console.log(this.state.quotations);
          }
        );
      })
      .catch(error => {
        console.log(error);
      });
  }
}

export default QuotationList;
