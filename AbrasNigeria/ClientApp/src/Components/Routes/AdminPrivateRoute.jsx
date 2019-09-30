import React from "react";
import { Route, Redirect } from "react-router-dom";
import userService from "../../Services/userService";

const AdminPrivateRoute = ({ component: Component, ...rest }) => {
  const user = userService.getCurrentUser();
  return (
    <Route
      {...rest}
      render={props =>
        user &&
        user.role ===
          (userService.roles.ADMIN || userService.roles.SUPER_ADMIN) ? (
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
};

export default AdminPrivateRoute;
