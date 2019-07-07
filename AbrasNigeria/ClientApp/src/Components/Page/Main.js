import React, { Component } from "react";
import Info from "../Content/Info";
import Table from "../Content/Table";

class Main extends Component {
  render() {
    return (
      <React.Fragment>
        <div className="container">
          <Info />
          <Table />
        </div>
      </React.Fragment>
    );
  }
}

export default Main;
