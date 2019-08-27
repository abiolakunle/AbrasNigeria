import React, { Component } from "react";

import { Link } from "react-router-dom";
import axios from "axios";

import DasboardIndex from "./DashboardIndex";

class DocumentList extends Component {
  state = {
    documents: []
  };
  render() {
    return (
      <DasboardIndex>
        <React.Fragment>
          <Link to="/admin/document/new">
            <button className="btn btn-primary my-2 ml-5">
              Create new document
            </button>
          </Link>
          <ul className="list-group">
            {this.state.documents.map(document => {
              return (
                <React.Fragment>
                  <li
                    key={document.documentId}
                    className="list-group-item  justify-content-between align-items-center"
                  >
                    <div className="row">
                      <div className="col-md-5">
                        <Link to={`/admin/document/${document.documentId}`}>
                          <span className="font-weight-bold">
                            Document Number:{" "}
                          </span>
                          {document.documentNo}
                        </Link>
                      </div>
                      <div className="col-md-3">
                        <span className="font-weight-bold">Company: </span>
                        {document.company}
                      </div>
                      <div className="col-md-3">
                        <span className="font-weight-bold">Date: </span>
                        {new Date(document.date).toDateString()}
                      </div>
                      <div className="col-md-1">
                        <span className="badge badge-primary badge-pill">
                          {document.table.length} item(s)
                        </span>
                      </div>
                    </div>
                  </li>
                </React.Fragment>
              );
            })}
          </ul>
        </React.Fragment>
      </DasboardIndex>
    );
  }

  componentDidMount() {
    this.getDocuments();
  }

  getDocuments() {
    axios
      .get("/api/document/documents")
      .then(response => {
        this.setState(
          {
            documents: response.data
          },
          () => {
            console.log(this.state.documents);
          }
        );
      })
      .catch(error => {
        console.log(error);
      });
  }
}

export default DocumentList;
