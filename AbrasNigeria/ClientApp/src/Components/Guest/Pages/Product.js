import React, { Component } from "react";

import axios from "axios";

import AddToCartBtn from "../Partials/AddToCartBtn";
import HeaderFooter from "../Shared/HeaderFooter";

export default class Product extends Component {
  state = {
    productId: "",
    partNumber: "",
    categories: [],
    brand: "",
    machines: [],
    sectionGroups: []
  };

  componentDidMount() {
    this.loadProduct();
  }

  render() {
    const { productId, partNumber, categories, brand } = this.state;
    const product = { productId, partNumber, categories };

    return (
      <HeaderFooter>
        <React.Fragment>
          <div>
            <span className="badge badge-dark">Part number</span>
            <h3>{partNumber}</h3>
            <AddToCartBtn product={product} />
            <hr />
            <p>
              <span className="font-weight-bold">Categories: </span>
              {categories.map((category, index) => {
                return (
                  <span key={index}>{`${index > 0 ? " | " : ""} ${
                    category.categoryName
                  }`}</span>
                );
              })}
            </p>
            <p>
              <span className="font-weight-bold">Brand: </span>
              {brand}
            </p>
          </div>
          {this.renderDetailTab(this.state.machines, this.state.sectionGroups)}
        </React.Fragment>
      </HeaderFooter>
    );
  }

  loadProduct = () => {
    let apiUrl = `/api/product/product?productid=${this.props.match.params.id}`;

    axios
      .get(apiUrl)
      .then(response => {
        const {
          productId,
          partNumber,
          brand,
          categories,
          sectionGroups,
          machines
        } = response.data;

        this.setState({
          productId,
          partNumber,
          brand,
          categories,
          sectionGroups,
          machines
        });
      })
      .catch(error => {
        console.error(error);
      });
  };

  renderDetailTab = (machines, sectionGroups) => {
    return (
      <React.Fragment>
        <ul className="nav nav-tabs mt-5" id="myTab" role="tablist">
          <li className="nav-item">
            <a
              className="nav-link active"
              id="home-tab"
              data-toggle="tab"
              href="#machines"
              role="tab"
              aria-controls="machines"
              aria-selected="true"
            >
              Machines
            </a>
          </li>
          <li className="nav-item">
            <a
              className="nav-link"
              id="profile-tab"
              data-toggle="tab"
              href="#sectionGroups"
              role="tab"
              aria-controls="sectionGroups"
              aria-selected="false"
            >
              SectionGroups
            </a>
          </li>
        </ul>
        <div className="tab-content mt-3" id="myTabContent">
          <div
            className="tab-pane fade show active "
            id="machines"
            role="tabpanel"
            aria-labelledby="home-tab"
          >
            {machines.map((machine, index) => {
              return (
                <div Key={index}>
                  <span className="badge badge-dark badge-pill p-1 mr-1 mb-2">
                    {index + 1}
                  </span>{" "}
                  {this.state.brand} {machine.modelName}
                </div>
              );
            })}
          </div>
          <div
            className="tab-pane fade"
            id="sectionGroups"
            role="tabpanel"
            aria-labelledby="profile-tab"
          >
            {sectionGroups.map((sectionGroup, index) => {
              return (
                <div Key={index}>
                  <span className="badge badge-dark badge-pill p-1 mr-1 mb-2">
                    {index + 1}
                  </span>{" "}
                  {sectionGroup.sectionGroupName}
                </div>
              );
            })}
          </div>
        </div>
      </React.Fragment>
    );
  };
}
