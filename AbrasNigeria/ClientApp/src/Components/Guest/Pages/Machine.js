import React, { Component } from "react";
import axios from "axios";

export default class Machine extends Component {
  state = {
    machine: {}
  };
  render() {
    return <div />;
  }

  componentDidMount() {
    axios
      .get("https://localhost:44343/api/machine/machine?id=88")
      .then(response => {
        console.log(response.data);
      })
      .catch(error => {
        console.log(error);
      });
  }
}
