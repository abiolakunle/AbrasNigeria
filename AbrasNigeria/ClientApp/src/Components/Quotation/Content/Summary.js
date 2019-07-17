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

              <div className="my-5"> {NumInWords(contextState.total)} </div>
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
