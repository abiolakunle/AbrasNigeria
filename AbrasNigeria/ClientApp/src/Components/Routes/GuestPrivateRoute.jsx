import React from "react";
import { Route, Redirect } from "react-router-dom";

import userService from "../../Services/userService";

const GuestPrivateRoute = ({ component: Component, ...rest }) => {
  const user = userService.getCurrentUser();
  console.log("User", user);
  return (
    <Route
      {...rest}
      render={props =>
        user && user.role === userService.roles.GUEST ? (
          <Component {...props} />
        ) : (
          <Redirect
            to={{
              pathname: "/guest/auth/login",
              state: { from: props.location }
            }}
          />
        )
      }
    />
  );
};

export default GuestPrivateRoute;
