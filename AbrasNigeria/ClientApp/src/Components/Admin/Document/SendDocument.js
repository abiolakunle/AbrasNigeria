import React, { Component } from "react";

import DasboardIndex from "../Shared/AdminNav";

import axios from "axios";

class SendQuotation extends Component {
  state = {
    quoteDate: "",
    quoteNumber: "",
    company: "",
    email: "",
    subject: "",
    message: "",
    attachmentId: ""
  };

  componentDidMount() {
    this.getQuotation();
    this.setState({
      attachmentId: this.props.match.params.id
    });
  }

  render() {
    return (
      <DasboardIndex>
        <React.Fragment>
          <div>Send Mail</div>
          <div className="container">
            <form>
              <div className="form-group">
                <label for="name">To email</label>
                <input
                  type="text"
                  className="form-control"
                  id="name"
                  aria-describedby="emailHelp"
                  placeholder="Enter name"
                />
              </div>
              <div className="form-group">
                <label for="email">Subject</label>
                <input
                  type="email"
                  className="form-control"
                  id="email"
                  aria-describedby="emailHelp"
                  placeholder="Enter email"
                />
              </div>
              <div className="form-group">
                <label for="message">Message</label>
                <textarea className="form-control" id="message" rows="6" />
              </div>

              <div className="form-group">
                <label for="attachments">Attachments</label>
                <div className=" form-control badge badge-primary badge-pill">
                  {this.state.company + " " + this.state.quoteNumber}
                </div>
              </div>
              <div className="mx-auto">
                <button
                  onClick={event => this.send(this.props, event)}
                  type="submit"
                  className="btn btn-primary text-right"
                >
                  Send
                </button>
              </div>
            </form>
          </div>
        </React.Fragment>
      </DasboardIndex>
    );
  }

  getQuotation() {
    axios.get(`/api/Quotation/${this.props.match.params.id}`).then(response => {
      const { quoteNo, date, company } = response.data;
      this.setState({
        quoteNumber: quoteNo,
        quoteDate: date,
        company
      });
    });
  }

  send(props, event) {
    event.preventDefault();
    const id = props.match.params.id;
    axios.post(`/api/Mail/send`, {
      attachmentId: id
    });
  }
}

export default SendQuotation;
