import React, { Component } from "react";
import { connect } from "react-redux";

import { login } from "../../../Actions/authActions";

import userService from "../../../Services/userService";

import HeaderFooter from "../Shared/HeaderFooter";

class Login extends Component {
  state = {
    username: "",
    password: ""
  };

  render() {
    const { username, password } = this.state;
    const { history } = this.props;
    const user = userService.getCurrentUser();

    user &&
      user.role === userService.roles.GUEST &&
      history.push("/guest/cart");

    return (
      <HeaderFooter>
        <React.Fragment>
          <form onSubmit={this.handleSubmit}>
            <div className="form-group row">
              <label for="inputEmail3" className="col-sm-2 col-form-label">
                Username
              </label>
              <div className="col-sm-10">
                <input
                  type="text"
                  className="form-control"
                  id="inputUserName"
                  placeholder="UserName"
                  name="username"
                  value={username}
                  onChange={this.handleChange}
                />
              </div>
            </div>
            <div className="form-group row">
              <label for="inputPassword3" className="col-sm-2 col-form-label">
                Password
              </label>
              <div className="col-sm-10">
                <input
                  type="password"
                  className="form-control"
                  id="inputPassword3"
                  placeholder="Password"
                  name="password"
                  value={password}
                  onChange={this.handleChange}
                />
              </div>
            </div>

            <div className="form-group row">
              <div className="col-sm-2"></div>
              <div className="col-sm-10">
                <div className="form-check">
                  <input
                    className="form-check-input"
                    type="checkbox"
                    id="gridCheck1"
                  />
                  <label className="form-check-label" for="gridCheck1">
                    Remember me
                  </label>
                </div>
              </div>
            </div>
            <div className="form-group row">
              <div className="col-sm-10">
                <button type="submit" className="btn btn-primary">
                  Login
                </button>
              </div>
            </div>
          </form>
        </React.Fragment>
      </HeaderFooter>
    );
  }

  componentWillUpdate() {}

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

    this.props.login({ username, password });
  };
}

const mapStateToProps = ({ authReducer }) => {
  const { isLoggingIn, isLoggedIn } = authReducer;
  return {
    isLoggedIn,
    isLoggingIn
  };
};

const mapDispatchToProps = dispatch => {
  return {
    login: user => dispatch(login(user))
  };
};

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Login);
