import React, { Component } from "react";
import axios from "axios";

import AddToCartBtn from "../Partials/AddToCartBtn";
import HeaderFooter from "../Shared/HeaderFooter";

export default class Machine extends Component {
  state = {
    machine: {},
    sections: []
  };

  componentDidMount() {
    this.loadMachine();
  }

  render() {
    return (
      <HeaderFooter>
        <React.Fragment>
          <div className="my-3">
            <h1 className="my-2">
              {this.state.machine.brandName} {this.state.machine.modelName}
            </h1>
            <hr />
            {this.state.sections.map((section, index) => {
              return (
                <div Key={index} id=" accordion">
                  <div className="card shadow-sm" id="headingOne">
                    <button
                      className="btn btn-link"
                      data-toggle="collapse"
                      data-target={`.${
                        section.sectionName.toLowerCase().split(" ")[0]
                      }`}
                      aria-expanded="false"
                      aria-controls={section.sectionName.toLowerCase()}
                    >
                      <h5 className="d-flex justify-content-between mb-0 py-2">
                        {section.sectionName}
                        <span className="fas fa-chevron-down ml-auto m-2" />
                      </h5>
                    </button>
                  </div>
                  <div className="list-group list-group-flush">
                    {section.sectionGroups.map((sectionGroup, index) => {
                      return (
                        <div
                          Key={index}
                          id={section.sectionName.toLowerCase()}
                          className={`list-group-item collapse ${
                            section.sectionName.toLowerCase().split(" ")[0]
                          }`}
                          aria-labelledby="headingOne"
                          data-parent="#accordion"
                        >
                          <div className="card-body py-0">
                            <div className=" w-100 badge badge-dark p-2">
                              {sectionGroup.sectionGroupName}
                            </div>

                            <table className="table table-sm table-striped">
                              <thead>
                                <tr>
                                  <th scope="col">#</th>
                                  <th scope="col">Part Number</th>
                                  <th scope="col">Descriptions</th>
                                  <th scope="col">Quantity</th>
                                  <th scope="col">Serial No.</th>
                                  <th scope="col">Remark</th>
                                  <th scope="col">Cart</th>
                                </tr>
                              </thead>
                              <tbody>
                                {sectionGroup.products.map((product, index) => {
                                  return (
                                    <tr>
                                      <th scope="row">{index + 1}</th>
                                      <td>{product.partNumber}</td>
                                      <td>
                                        {product.descriptions.map(
                                          (description, index) => {
                                            return (
                                              <span key={index}>{` ${
                                                index > 0 ? " | " : ""
                                              }${
                                                description.descriptionName
                                              }  `}</span>
                                            );
                                          }
                                        )}
                                      </td>
                                      <td>{product.quantity}</td>
                                      <td>{product.serialNo}</td>
                                      <td>{product.remark}</td>
                                      <td>
                                        <AddToCartBtn product={product} />
                                      </td>
                                    </tr>
                                  );
                                })}
                              </tbody>
                            </table>
                          </div>
                        </div>
                      );
                    })}
                  </div>
                </div>
              );
            })}
          </div>
        </React.Fragment>
      </HeaderFooter>
    );
  }

  loadMachine = () => {
    //loads machine details from server and assign data from response into state
    axios
      .get(`/api/machine/machine?id=${this.props.match.params.id}`)
      .then(({ data }) => {
        console.log("Data", data);
        this.setState({
          machine: data,
          sections: data.sections
        });
        console.log(data);
      })
      .catch(error => {
        console.log(error);
      });
  };
}
