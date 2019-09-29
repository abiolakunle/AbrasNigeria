import React from "react";
import { Route, Redirect } from "react-router-dom";

import { GUEST } from "../../Constants/rolesConstants";

const GuestPrivateRoute = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={props =>
      localStorage.getItem(GUEST) ? (
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

export default GuestPrivateRoute;
