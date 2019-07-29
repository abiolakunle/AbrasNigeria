import React, { Component } from "react";

import axios from "axios";

import AddToCartBtn from "../Partials/AddToCartBtn";

export default class Product extends Component {
  state = {
    partNumber: "",
    category: "",
    brand: "",
    machines: [],
    sectionGroups: []
  };

  componentDidMount() {
    this.loadProduct();
  }

  render() {
    const { partNumber, category, brand } = this.state;
    const product = { partNumber, category };

    return (
      <React.Fragment>
        <div>
          <span className="badge badge-dark">Part number</span>
          <h3>{partNumber}</h3>
          <AddToCartBtn product={product} />
          <hr />
          <p>
            <span class="font-weight-bold">Category: </span>
            {category}
          </p>
          <p>
            <span class="font-weight-bold">Brand: </span>
            {brand}
          </p>
        </div>
        {this.renderDetailTab(this.state.machines, this.state.sectionGroups)}
      </React.Fragment>
    );
  }

  loadProduct = () => {
    let apiUrl = `https://localhost:44343/api/product/product?productid=${
      this.props.match.params.id
    }`;

    axios
      .get(apiUrl)
      .then(response => {
        const {
          partNumber,
          brand,
          category,
          sectionGroups,
          machines
        } = response.data;

        this.setState(
          {
            partNumber,
            brand,
            category,
            sectionGroups,
            machines
          },
          () => {
            console.log(this.state);
          }
        );
      })
      .catch(error => {
        console.error(error);
      });
  };

  renderDetailTab = (machines, sectionGroups) => {
    return (
      <React.Fragment>
        <ul class="nav nav-tabs mt-5" id="myTab" role="tablist">
          <li class="nav-item">
            <a
              class="nav-link active"
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
          <li class="nav-item">
            <a
              class="nav-link"
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
        <div class="tab-content mt-3" id="myTabContent">
          <div
            class="tab-pane fade show active "
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
            class="tab-pane fade"
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
