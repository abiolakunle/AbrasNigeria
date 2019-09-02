import React, { Component } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

import LoadingOverlay from "react-loading-overlay";
import { getDocuments } from "../../../Actions/documentActions";

import AdminNav from "../Shared/AdminNav";

class DocumentList extends Component {
  render() {
    const { documents, isLoaded, isLoading } = this.props;
    return (
      <AdminNav>
        <LoadingOverlay active={isLoading} spinner text="Loading Documents">
          <React.Fragment>
            <Link to="/admin/document/new">
              <button className="btn btn-primary my-2 ml-5">
                Create new document
              </button>
            </Link>
            <ul className="list-group">
              {documents.map(document => {
                return (
                  <React.Fragment key={document.documentId}>
                    <li className="list-group-item  justify-content-between align-items-center">
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
        </LoadingOverlay>
      </AdminNav>
    );
  }

  componentDidMount() {
    this.props.getDocuments();
  }
}

const mapStateToProps = ({ documentReducer }) => {
  const { documents, isLoading, isLoaded } = documentReducer;
  return {
    documents,
    isLoaded,
    isLoading
  };
};
const mapDispatchToProps = dispatch => {
  return {
    getDocuments: () => dispatch(getDocuments())
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(DocumentList);