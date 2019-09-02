import React, { Component } from "react";
import { connect } from "react-redux";

import AuthIndex from "../Shared/AuthNav";
import { register } from "../../../Actions/authActions";

class Register extends Component {
  state = {
    username: "",
    password: ""
  };

  render() {
    const { username, password } = this.state;
    const { history, isRegistered } = this.props;
    console.log(this.props);
    if (isRegistered === true) {
      history.push("/admin/auth/login");
    }
    return (
      <AuthIndex>
        <React.Fragment>
          <form onSubmit={this.handleSubmit}>
            <div class="form-group row">
              <label for="inputEmail3" class="col-sm-2 col-form-label">
                Username
              </label>
              <div class="col-sm-10">
                <input
                  type="text"
                  class="form-control"
                  id="inputUserName"
                  placeholder="UserName"
                  name="username"
                  value={username}
                  onChange={this.handleChange}
                />
              </div>
            </div>
            <div class="form-group row">
              <label for="inputPassword3" class="col-sm-2 col-form-label">
                Password
              </label>
              <div class="col-sm-10">
                <input
                  type="password"
                  class="form-control"
                  id="inputPassword3"
                  placeholder="Password"
                  name="password"
                  value={password}
                  onChange={this.handleChange}
                />
              </div>
            </div>

            <div class="form-group row">
              <div class="col-sm-2"></div>
              <div class="col-sm-10">
                <div class="form-check">
                  <input
                    class="form-check-input"
                    type="checkbox"
                    id="gridCheck1"
                  />
                  <label class="form-check-label" for="gridCheck1">
                    Remember me
                  </label>
                </div>
              </div>
            </div>
            <div class="form-group row">
              <div class="col-sm-10">
                <button type="submit" class="btn btn-primary">
                  Register
                </button>
              </div>
            </div>
          </form>
        </React.Fragment>
      </AuthIndex>
    );
  }

  handleChange = event => {
    const eventName = event.target.name;
    const eventValue = event.target.value;

    this.setState({
      [eventName]: eventValue
    });
  };

  handleSubmit = event => {
    event.preventDefault();

    const { username, password } = this.state;
    this.props.register({ username, password });
  };
}

const mapStateToProps = ({ authReducer }) => {
  const { isRegistering, isRegistered } = authReducer;
  return {
    isRegistered,
    isRegistering
  };
};

const mapDispatchToProps = dispatch => {
  return {
    register: user => dispatch(register(user))
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Register);
