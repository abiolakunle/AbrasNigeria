import React, { Component } from "react";
import axios from "axios";

import NumInWords from "../Utils/NumInWords";
import TableItem from "./Content/TableItem";
import Header from "./Page/Header";
import Footer from "./Page/Footer";

class ViewQuotation extends Component {
  state = {
    quoteNo: "",
    company: "",
    date: "",
    table: [],
    total: 0
  };

  componentDidMount() {
    //get quotation from api call  with id
    axios
      .get(
        `https://localhost:44343/api/Quotation/${this.props.match.params.id}`
      )
      .then(response => {
        const { quoteNo, company, date, table } = response.data;
        this.setState(
          Object.keys(response.data).length //check if response contains data
            ? {
                quoteNo,
                company,
                date: new Date(date).toISOString().split("T")[0],
                table,
                total: this.calculateTotal(table)
              }
            : {}
        );

        console.log(this.state.table);
      });
  }

  render() {
    return (
      <React.Fragment>
        <link
          rel="stylesheet"
          href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"
        />
        <Header />
        <div>{this.renderInfo()}</div>
        <table className="table table-striped">
          {this.renderTableHead()}
          <tbody>
            {this.state.table.map((item, index) => {
              return <TableItem key={index} index={index} item={item} />;
            })}
          </tbody>
          <tfoot>
            <tr>
              <td />
              <td />
              <td />
              <td />
              <td className="blue-grey lighten-2 font-weight-bold py-2">
                GrandTotal
              </td>
              <td className="blue-grey lighten-4 py-2">
                <strong>{this.state.total.toLocaleString()}</strong>
              </td>
            </tr>
          </tfoot>
        </table>
        <div className="row my-5">
          <div className="col-md-4 blue-grey lighten-2 font-weight-bold py-2">
            Amount in words:{" "}
          </div>
          <div className="col-md-8 blue-grey lighten-4 py-2">
            {NumInWords(this.state.total)}
          </div>
        </div>
        <Footer />
      </React.Fragment>
    );
  }

  calculateTotal = itemsIn => {
    var total = 0;
    itemsIn.forEach(item => {
      total = total + item.unitPrice * item.quantity;
    });

    this.setState({
      total: total
    });
    return total;
  };

  renderInfo() {
    return (
      <div className="row">
        <div className="col-md-6">
          <div className=" row">
            <div className="col-md-3 blue-grey lighten-2 font-weight-bold py-2">
              To:
            </div>
            <div className="col-md-9  blue-grey lighten-4 py-2">
              <span>{this.state.company}</span>
            </div>
          </div>
        </div>
        <div className="col-md-6">
          <div className="row">
            <div className="col-md-3 blue-grey lighten-2 font-weight-bold py-2">
              Quote No:
            </div>
            <div className="col-md-9  blue-grey lighten-4 py-2">
              <span>{this.state.quoteNo}</span>
            </div>
          </div>
          <div className=" row">
            <div className="col-md-3 blue-grey lighten-2 font-weight-bold py-2">
              Date:
            </div>
            <div className="col-md-9  blue-grey lighten-4 py-2">
              <span>{this.state.date}</span>
            </div>
          </div>
        </div>
      </div>
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

export default ViewQuotation;
