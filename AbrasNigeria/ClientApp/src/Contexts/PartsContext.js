import React, { Component } from "react";

export const Context = React.createContext();

const reducer = (state, action) => {
  switch (action.type) {
    case "LOAD_MACHINES":
      return {};
    default:
  }
};

export default class PartsContext extends Component {
  state = {
    brands: [],
    machines: [],
    sections: [],
    sectionGroups: [],
    categories: [],
    products: [],
    dispatch: action => this.setState(state => reducer(state, action))
  };

  render() {
    return (
      <Context.Provider
        value={{
          contextState: this.state
        }}
      >
        {this.props.children}
      </Context.Provider>
    );
  }
}

export const PartsConsumer = Context.Consumer;
