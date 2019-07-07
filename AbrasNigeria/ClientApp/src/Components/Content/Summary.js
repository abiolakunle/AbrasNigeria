import React, { Component } from "react";
import NumInWords from "../../Utils/NumInWords";

import { Consumer } from "../../Context";

class Summary extends Component {
  render() {
    return (
      <Consumer>
        {contextValue => {
          const { contextState } = contextValue;
          return (
            <React.Fragment>
              <div className="my-5"> {NumInWords(contextState.total)} </div>
            </React.Fragment>
          );
        }}
      </Consumer>
    );
  }
}

export default Summary;
