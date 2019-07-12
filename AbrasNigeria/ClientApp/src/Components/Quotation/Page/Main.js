import React, { Component } from "react";
import Info from "../Content/Info";
import Table from "../Content/Table";

import { Redirect } from "react-router";

import { Consumer } from "../../../Context";

class Main extends Component {
  render() {
    return (
      <Consumer>
        {contextValue => {
          const { contextState } = contextValue;
          if (contextState.submitted === true) {
            contextState.submitted = false;
            return <Redirect to="/" />; //handle redirection to list on submit when submitted is true
          } else {
            return (
              <React.Fragment>
                <div className="container">
                  <Info />
                  <Table />
                </div>
              </React.Fragment>
            );
          }
        }}
      </Consumer>
    );
  }
}

export default Main;
