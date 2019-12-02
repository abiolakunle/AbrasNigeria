import React, { Component } from "react";
import { connect } from "react-redux";

import HeaderFooter from "../Shared/HeaderFooter";
import { register } from "../../../Actions/authActions";
import userService from "../../../Services/userService";

class Register extends Component {
  state = {
    username: "",
    password: ""
  };

  render() {
    const { username, password } = this.state;
    const { history, isRegistered } = this.props;
    (userService.getCurrentUser() || isRegistered) &&
      history.push("/guest/cart");

    return (
      <HeaderFooter>
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
      </HeaderFooter>
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

    const role = userService.roles.GUEST;
    const { username, password } = this.state;
    const user = {
      username,
      password,
      role
    };
    this.props.register(user);
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