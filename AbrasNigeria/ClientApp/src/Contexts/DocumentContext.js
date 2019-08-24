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
      return {
        ...state,
        table: action.payload.items,
        total: action.payload.total
      };

    case "SUMMARY":
      console.log(action.payload);
      return {
        ...state,
        note: action.payload
      };

    default:
      return state;
  }
};

export class DocumentProvider extends Component {
  state = {
    info: {},
    table: [],
    note: "",
    total: 0,
    submitted: false,
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
        note: this.state.note,
        table: [...this.state.table]
      }
    );

    console.log("New Invoice", invoice);
    axios
      .post("/api/Quotation", invoice)
      .then(response => {
        this.setState({
          submitted: true
        });
      })
      .catch(error => {
        console.log(error);
      });
  };
}

export const DocumentConsumer = Context.Consumer;
