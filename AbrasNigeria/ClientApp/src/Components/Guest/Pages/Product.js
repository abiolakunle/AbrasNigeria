import React, { Component } from "react";

import axios from "axios";

export default class Product extends Component {
  state = {
    products: {}
  };

  componentDidMount() {
    this.loadProduct();
  }

  render() {
    return <div />;
  }

  loadProduct = () => {
    let apiUrl = `https://localhost:44343/api/product/product?productid=${
      this.props.match.params.id
    }`;

    axios
      .get(apiUrl)
      .then(response => {
        this.setState(
          {
            products: response.data
          },
          () => {
            console.log(this.state.products);
          }
        );
      })
      .catch(error => {
        console.error(error);
      });
  };
}
