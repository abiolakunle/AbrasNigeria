import React from "react";
import { Route, Redirect } from "react-router-dom";
import userService from "../../Services/userService";

const AdminPrivateRoute = ({
  component: Component,
  roles = [userService.roles.ADMIN],
  ...rest
}) => {
  const user = userService.getCurrentUser();
  console.log("USER", user);
  return (
    <Route
      {...rest}
      render={props =>
        user && roles.includes(user.role) ? (
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
