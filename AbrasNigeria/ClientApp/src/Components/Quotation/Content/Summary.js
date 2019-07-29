import React, { Component } from "react";
import NumInWords from "../../../Utils/NumInWords";

import { DocumentConsumer } from "../../../Contexts/DocumentContext";

class Summary extends Component {
  state = {
    note: ""
  };
  render() {
    return (
      <DocumentConsumer>
        {contextValue => {
          const { contextState } = contextValue;
          return (
            <React.Fragment>
              <div className="row">
                <div className="col-md-6">
                  <textarea
                    className="form-control float-left my-3"
                    rows="6"
                    name="note"
                    placeholder="Note and addtional information"
                    value={this.props.note}
                    onChange={this.onFormChanged.bind(
                      this,
                      contextState.dispatch
                    )}
                  />
                </div>
              </div>

              {contextState.total !== "" ? (
                <div className="row my-5 text-primary">
                  <div className="col-md-4 blue darken-4 font-weight-bold py-2">
                    Amount in words:{" "}
                  </div>
                  <div className="col-md-8 blue darken-2 py-2">
                    {NumInWords(contextState.total)} Naira only
                  </div>
                </div>
              ) : (
                <div />
              )}
            </React.Fragment>
          );
        }}
      </DocumentConsumer>
    );
  }

  onFormChanged(dispatch, event) {
    this.setState(
      {
        [event.target.name]: event.target.value
      },
      () => {
        dispatch({
          type: "SUMMARY",
          payload: this.state.note
        });
      }
    );
  }
}

export default Summary;
