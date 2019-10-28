import React, { Component } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

import LoadingOverlay from "react-loading-overlay";
import { getDocuments, deleteDocument } from "../../../Actions/documentActions";

import SideNavbar from "../Shared/SideNavbar";

class DocumentList extends Component {
  render() {
    const {
      documents,
      isLoaded,
      isLoading,
      isDeleted,
      isDeleting
    } = this.props;

    isDeleted && window.location.reload();

    return (
      <React.Fragment>
        <SideNavbar>
          <LoadingOverlay
            active={(isLoading && !isLoaded) || isDeleting}
            spinner
            text="Loading Documents"
          >
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
                      <li className="list-group-item justify-content-between align-items-center">
                        <div className="row">
                          <div className="col-md-4">
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
                          <div className="col-md-1">
                            <div className="row">
                              <Link
                                to={`/admin/document/edit/${document.documentId}`}
                              >
                                <span class="far fa-edit fa-2x text-secondary"></span>
                              </Link>
                              <button
                                onClick={() => {
                                  this.handleDeleteDocument(
                                    document.documentId
                                  );
                                }}
                                className="btn btn-white p-0"
                              >
                                <span class="far fa-times-circle fa-2x text-secondary"></span>
                              </button>
                            </div>
                          </div>
                        </div>
                      </li>
                    </React.Fragment>
                  );
                })}
              </ul>
            </React.Fragment>
          </LoadingOverlay>
        </SideNavbar>
      </React.Fragment>
    );
  }

  handleDeleteDocument = id => {
    this.props.deleteDocument(id);
  };

  componentDidMount() {
    this.props.getDocuments();
  }
}

const mapStateToProps = ({ documentReducer }) => {
  const {
    documents,
    isLoading,
    isLoaded,
    isDeleting,
    isDeleted
  } = documentReducer;
  return {
    documents,
    isDeleting,
    isDeleted,
    isLoaded,
    isLoading
  };
};
const mapDispatchToProps = dispatch => {
  return {
    getDocuments: () => dispatch(getDocuments()),
    deleteDocument: id => dispatch(deleteDocument(id))
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(DocumentList);
