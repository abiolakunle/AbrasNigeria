import React from "react";
import { Route, Redirect } from "react-router-dom";
import { ADMIN } from "../../Constants/rolesConstants";

const AdminPrivateRoute = ({ component: Component, ...rest }) => (
  <Route
    {...rest}
    render={props =>
      localStorage.getItem(ADMIN) ? (
        <Component {...props} />
      ) : (
        <Redirect
          to={{
            pathname: "/admin/auth/login",
            state: { from: props.location }
          }}
        />
      )
    }
  />
);

export default AdminPrivateRoute;
