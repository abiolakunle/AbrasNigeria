import React, { Component } from "react";
import axios from "axios";

export default class Machine extends Component {
  state = {
    machine: {},
    sections: []
  };
  render() {
    return (
      <React.Fragment>
        <main className="container my-5">
          <div className="my-3">
            <h1 className="my-2">{this.state.machine.modelName}</h1>
            {this.state.sections.map((section, index) => {
              return (
                <div Key={index} id="accordion">
                  <div className="card shadow-sm" id="headingOne">
                    <h5 className="mb-0 py-2">
                      <button
                        className="btn btn-link"
                        data-toggle="collapse"
                        data-target={`.${
                          section.sectionName.toLowerCase().split(" ")[0]
                        }`}
                        aria-expanded="false"
                        aria-controls={section.sectionName.toLowerCase()}
                      >
                        {section.sectionName}
                      </button>
                    </h5>
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
                            <div className="badge badge-pill badge-primary p-2">
                              {sectionGroup.sectionGroupName}
                            </div>
                            {sectionGroup.products.map(product => {
                              return (
                                <div>
                                  <span>{product.category} </span>
                                  {product.partNumber}
                                </div>
                              );
                            })}
                          </div>
                        </div>
                      );
                    })}
                  </div>
                </div>
              );
            })}
          </div>
        </main>
      </React.Fragment>
    );
  }

  componentDidMount() {
    axios
      .get(
        `https://localhost:44343/api/machine/machine?id=${
          this.props.match.params.id
        }`
      )
      .then(({ data }) => {
        this.setState({
          machine: data,
          sections: data.sections
        });
        console.log(data);
      })
      .catch(error => {
        console.log(error);
      });
  }
}
