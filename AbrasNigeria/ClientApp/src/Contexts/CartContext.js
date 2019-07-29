import React, { Component } from "react";

export const Context = React.createContext();

const reducer = (state, action) => {
  switch (action.type) {
    case "ADD_TO_CART":
      return {};
    default:
  }
};

export default class CartProvider extends Component {
  state = {
    cartItems: [],
    dispatch: action => this.setState(state => reducer(state, action))
  };

  render() {
    return (
      <Context.Provider
        value={{
          contextState: this.state,
          addToCart: this.addToCart,
          syncWithCart: this.syncWithCart,
          changeQuantity: this.changeQuantity
        }}
      >
        {this.props.children}
      </Context.Provider>
    );
  }

  addToCart = product => {
    console.log(product);
    let tempCartItems = [...this.state.cartItems]; ///copy cart item to temporary array

    //checks if item is in cart already and decide to add or remove
    if (tempCartItems.some(item => item.partNumber === product.partNumber)) {
      //filter out if item exists
      tempCartItems = tempCartItems.filter(item => {
        return item.partNumber !== product.partNumber;
      });
    } else {
      //add item to temporary array
      tempCartItems.push(product);
    }

    //update cart
    this.setState({
      cartItems: [...tempCartItems]
    });
  };

  changeQuantity = (product, quantity) => {
    console.log(product, quantity);
    let tempCartItems = [...this.state.cartItems];

    let productIndex = tempCartItems.findIndex(
      item => item.partNumber === product.partNumber
    );

    tempCartItems[productIndex].quantity = quantity;

    console.log("new cart items", tempCartItems);
    this.setState({
      cartItems: [...tempCartItems]
    });
  };

  syncWithCart = partNumber => {
    let inCart = this.state.cartItems.some(
      item => item.partNumber === partNumber
    );
    return inCart;
  };
}

export const CartConsumer = Context.Consumer;
