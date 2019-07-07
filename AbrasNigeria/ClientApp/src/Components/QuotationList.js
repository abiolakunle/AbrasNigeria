import React, { Component } from "react";

import { Link } from "react-router-dom";

import axios from "axios";

class QuotationList extends Component {
  state = {
    quotations: []
  };
  render() {
    let quotationList = this.state.quotations.map(quotation => {
      return (
        <li
          key={quotation.quotationId}
          className="list-group-item  justify-content-between align-items-center"
        >
          <div className="row">
            <Link to={`/view/${quotation.quotationId}`}>
              <div className="col-md-3">
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
              {quotation.date}
            </div>
            <div className="col-md-3">
              <span className="badge badge-primary badge-pill">
                {quotation.table.length}
              </span>
            </div>
          </div>
        </li>
      );
    });
    return (
      <React.Fragment>
        <ul className="list-group">{quotationList}</ul>
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
        this.setState({
          quotations: response.data
        });
      })
      .catch(error => {
        console.log(error);
      });
  }
}

export default QuotationList;
