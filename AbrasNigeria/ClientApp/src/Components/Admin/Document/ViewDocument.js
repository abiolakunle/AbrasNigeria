import React, { Component } from "react";
import { Link } from "react-router-dom";
import axios from "axios";

import NumInWords from "../../../Utils/NumInWords";

import { authHeader } from "../../../Helpers/authHeader";

//imported images
import Cat from "../../../Images/c_caterpillar.png";
import Komatsu from "../../../Images/c_komatsu.png";
import Perkins from "../../../Images/c_perkins.png";
import Cummins from "../../../Images/c_cummins.png";
import Volvo from "../../../Images/c_volvo.png";
import logo from "../../../Images/Abras logo red.png";

import PrintPage from "../../Shared/PrintPage";
import PrintBtn from "../../Shared/PrintBtn";

class ViewDocument extends Component {
  state = {
    documentNo: "",
    refDocumentNo: "",
    company: "",
    note: "",
    documentType: "",
    date: "",
    table: [],
    total: 0
  };

  componentDidMount() {
    const requestOptions = {
      method: "POST",
      headers: { ...authHeader(), "Content-Type": "application/json" }
    };

    //get quotation from api call  with id
    axios
      .get(
        `/api/document/document?id=${this.props.match.params.id}`,
        requestOptions
      )
      .then(response => {
        const {
          documentNo,
          refDocumentNo,
          company,
          date,
          table,
          note,
          documentType
        } = response.data;
        this.setState(
          Object.keys(response.data).length //check if response contains data
            ? {
                documentNo,
                refDocumentNo,
                company,
                note,
                documentType,
                date: new Date(date).toISOString().split("T")[0],
                table,
                total: this.calculateTotal(table)
              }
            : {}
        );
      });
  }

  render() {
    return (
      <React.Fragment>
        <PrintBtn id={this.state.documentNo} label={"Download Document"} />
        <PrintPage id={this.state.documentNo}>
          <React.Fragment>
            <link
              rel="stylesheet"
              href="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/css/materialize.min.css"
            />
            {this.renderHeader(this.props.match.params.id)}

            <div className="mt-5">{this.renderInfo()}</div>
            <div className="d-flex justify-content-center">
              <h5 className="font-weight-bold mt-0 px-2 text-uppercase">
                {this.state.documentType}
              </h5>
            </div>
            <table className="table table-striped">
              {this.renderTableHead()}
              <tbody>
                {this.state.table.map((item, index) => {
                  return (
                    <tr key={index}>
                      <th scope="row">{index + 1}</th>
                      <td>{item.partNumber}</td>
                      <td>{item.description}</td>
                      <td className="text-right">
                        {(item.quantity * 1).toLocaleString()}
                      </td>
                      <td className="text-right">
                        {(item.unitPrice * 1).toLocaleString()}
                      </td>
                      <td className="text-right">
                        {(item.unitPrice * item.quantity).toLocaleString()}
                      </td>
                    </tr>
                  );
                })}
              </tbody>

              <tbody>
                <tr className="table-footer text-white">
                  <td />
                  <td />
                  <td />
                  <td />
                  <td className="red accent-4 font-weight-bold py-2">
                    GrandTotal
                  </td>
                  <td className="red lighten-1 py-2">
                    <strong>{this.state.total.toLocaleString()}</strong>
                  </td>
                </tr>
              </tbody>
            </table>
            <div className="row mx-5">
              <div className="card">
                <div className="card-header">Note:</div>
                <div className="card-body">{this.state.note}</div>
              </div>
            </div>
            <div className="row my-5 text-white">
              <div className="col-md-4 red accent-4 font-weight-bold py-1">
                Amount in words:{" "}
              </div>
              <div className="col-md-8 red lighten-1 py-1">
                {NumInWords(this.state.total)} Naira only
              </div>
            </div>
            <div className="d-flex">{`Ref.: ${this.state.refDocumentNo}`}</div>
            {this.renderFooter()}
          </React.Fragment>
        </PrintPage>
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

  renderHeader = ({ quoteNumber }) => {
    return (
      <React.Fragment>
        <div className="dropdown float-left">
          <button
            className="btn blue-grey lighten-5 "
            type="button"
            id="dropdownMenuButton"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          >
            <span className="fas fa-angle-down " />
          </button>
          <div className="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <Link to={`/send/${quoteNumber}`}>
              <div className="dropdown-item">
                <span className="far fa-envelope"> Send via mail</span>
              </div>
            </Link>
            <Link to="/admin/document/list">
              <div className="dropdown-item">
                <span>Document list</span>
              </div>
            </Link>
            <Link to="/admin/document/new">
              <div className="dropdown-item">
                <span>New Document</span>
              </div>
            </Link>
          </div>
        </div>

        <div className="container-fluid">
          <div className="d-flex justify-content-center mt-3">
            <img src={logo} width="50px" height="50px" alt="abras" />
          </div>
          <h3 className="d-flex text-center justify-content-center red-text text-darken-1 text-uppercase font-weight-bolder my-0">
            Abras nigeria enterprises
          </h3>
          <p className="d-flex text-center justify-content-center font-weight-bold mb-1">
            Suppliers of wide range of heavy duty equipment parts & maintenance
            services
          </p>
          <hr />
          <div className="row">
            <div className="col-md-6 col-sm-6">
              <div className="row my-1">
                <p className="mb-0">
                  <span className="font-weight-bold mr-1">Phone:</span>{" "}
                  08036775192, 08083458300
                </p>
              </div>

              <p className="row my-1">
                <span className="font-weight-bold mr-1">Email:</span>
                {"  "}
                abrasnigeriaent@gmail.com
              </p>
              <p className="row my-1">
                <span className="font-weight-bold mr-1">Website:</span>
                {"  "}
                www.abrasnigeria.com
              </p>
            </div>
            <div className="col-md-6 col-sm-6">
              <p className="row my-1">
                <span className="font-weight-bold mr-1">Addresses:</span>
                {"  "}
                10, Ajiboye Street, Ketu, Alapere, Lagos. <br /> 41 Ifeloju
                Street, Obada-Oko, Abeokuta
              </p>
            </div>
          </div>
        </div>
      </React.Fragment>
    );
  };

  renderInfo = () => {
    return (
      <div className="row text-white">
        <div className="col-md-6">
          <div className="row">
            <div className="col-md-3 red accent-4  font-weight-bold py-1">
              To:
            </div>
            <div className="col-md-9  red lighten-1 py-1">
              <span>{this.state.company}</span>
            </div>
          </div>
        </div>
        <div className="col-md-6">
          <div className="row">
            <div className="col-md-5 red accent-4 font-weight-bold py-1">
              Document No.:
            </div>
            <div className="col-md-7 red lighten-1 py-1">
              <span>{this.state.documentNo}</span>
            </div>
          </div>
          <div className=" row">
            <div className="col-md-3 red accent-4 font-weight-bold py-1">
              Date:
            </div>
            <div className="col-md-9  red lighten-1 py-1">
              <span>{this.state.date}</span>
            </div>
          </div>
        </div>
      </div>
    );
  };

  renderFooter = () => {
    return (
      <React.Fragment>
        <div className="container d-flex justify-content-around  py-5 mb-5">
          <div className="mb-5">
            <img src={Cat} height="50px" alt="Cat" />
          </div>
          <div className="">
            <img src={Komatsu} height="50px" alt="Komatsu" />
          </div>
          <div className="">
            <img src={Perkins} height="50px" alt="Perkins" />
          </div>
          <div className="">
            <img src={Cummins} height="50px" alt="Cummins" />
          </div>
          <div className="">
            <img src={Volvo} height="50px" alt="Volvo" />
          </div>
        </div>
      </React.Fragment>
    );
  };

  renderTableHead = () => {
    return (
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Part Number</th>
          <th scope="col">Description</th>
          <th scope="col " className="text-right">
            Quantity
          </th>
          <th scope="col " className="text-right">
            Unit Price
          </th>
          <th scope="col " className="text-right">
            Extended Price
          </th>
        </tr>
      </thead>
    );
  };
}

export default ViewDocument;
