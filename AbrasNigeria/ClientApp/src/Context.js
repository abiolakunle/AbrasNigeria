import React, { Component } from "react";

import axios from "axios";

export const Context = React.createContext();

const reducer = (state, action) => {
  switch (action.type) {
    case "INFO":
      console.log(action.payload);
      return {
        ...state,
        info: action.payload
      };

    case "TABLE_DATA":
      console.table(action.payload.items);
      return {
        ...state,
        table: action.payload.items,
        total: action.payload.total
      };

    default:
      return state;
  }
};

export class Provider extends Component {
  state = {
    info: {},
    table: [],
    total: 0,

    dispatch: action => this.setState(state => reducer(state, action))
  };

  render() {
    return (
      <Context.Provider
        value={{
          contextState: this.state,
          sendInvoice: this.sendInvoice
        }}
      >
        {this.props.children}
      </Context.Provider>
    );
  }

  sendInvoice = () => {
    let invoice = Object.assign(
      {},
      {
        ...this.state.info,
        table: [...this.state.table]
      }
    );

    console.log("New Invoice", invoice);
    axios
      .post("https://localhost:44343/api/Quotation", invoice)
      .then
      //res => {
      //console.log(res.data);
      //}
      ()
      .catch(error => {
        console.log(error);
      });
  };
}

export const Consumer = Context.Consumer;
