import React, { Component } from "react";

import axios from "axios";

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

  componentDidMount() {
    let apiUrl = "/api/cart/getcart";

    axios
      .get(apiUrl)
      .then(response => {
        const { data } = response;
        this.setState({
          cartItems: data
        });
      })
      .then(error => {
        console.error("Error", error);
      });
  }
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

  sendToServer = () => {
    let apiUrl = "/api/cart/updatecart";

    axios
      .post(apiUrl, this.state.cartItems)
      .then(response => {
        console.info(response.data);
      })
      .catch(error => {
        console.error(error);
      });
  };

  addToCart = product => {
    let tempCartItems = [...this.state.cartItems]; //copy cart item to temporary array

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
    this.setState(
      {
        cartItems: [...tempCartItems]
      },
      () => {
        this.sendToServer();
      }
    );
  };

  changeQuantity = (product, quantity) => {
    let tempCartItems = [...this.state.cartItems];

    let productIndex = tempCartItems.findIndex(
      item => item.partNumber === product.partNumber
    );

    tempCartItems[productIndex].quantity = quantity;

    this.setState({
      cartItems: [...tempCartItems]
    });
    this.sendToServer();
  };

  syncWithCart = partNumber => {
    let inCart = this.state.cartItems.some(
      item => item.partNumber === partNumber
    );
    return inCart;
  };
}

export const CartConsumer = Context.Consumer;
