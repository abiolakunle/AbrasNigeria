import React, { Component } from "react";
import axios from "axios";

export default class UploadExcel extends Component {
  state = {
    selectedFile: []
  };

  render() {
    return (
      <React.Fragment>
        <main id="excel-db" className="container mt-5">
          <div className="card mx-auto">
            <h3 className="card-header mb-5">Upload Master Table</h3>

            <form method="post" className="card-body pl-5">
              <div className="form-group">
                <label className="col-md-2 control-label font-weight-bold">
                  Master Table File
                </label>
                <div className="col-md-6">
                  <input
                    name="masterFile"
                    type="file"
                    className="form-control"
                    onChange={this.onFileChange}
                  />
                  <span className="text-danger" />
                </div>
              </div>
              <div className="form-group">
                <div className="btn-group col-md-offset-2 col-md-6">
                  <input
                    className="btn btn-primary"
                    type="submit"
                    value="Upload"
                    onClick={this.onFormSubmit}
                  />
                </div>
              </div>
            </form>
          </div>
        </main>
      </React.Fragment>
    );
  }

  onFileChange = event => {
    let file = event.target.files;
    let state = this.state;

    this.setState({
      ...state,
      selectedFile: file
    });
    console.log(this.state.selectedFile);
  };

  onFormSubmit = event => {
    event.preventDefault();
    let state = this.state;

    this.setState({
      ...state,
      justFileServiceResponse: "Please wait"
    });

    if (!state.hasOwnProperty("selectedFile")) {
      this.setState({
        ...state,
        justFileServiceResponse: "First select a file!"
      });
      return;
    }

    let form = new FormData();

    for (var i = 0; i < state.selectedFile.length; i++) {
      var element = state.selectedFile[i];
      form.append("masterFile", element);
    }

    let url = "https://localhost:44343/api/ExcelToDb/UploadExcel";

    axios
      .post(url, form)
      .then(response => {
        let message = "Succes!";
        if (!response.data.success) {
          message = response.data.messsage;
        }
        this.setState({
          ...state,
          justFileServiceResponse: message
        });
        console.log(form);
      })
      .catch(error => {
        console.log(error);
      });
  };
}
