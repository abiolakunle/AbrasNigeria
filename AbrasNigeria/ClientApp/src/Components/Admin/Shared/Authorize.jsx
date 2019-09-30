import React from "react";
import userService from "../../../Services/userService";

const Authorize = ({ role, children }) => {
  const user = userService.getCurrentUser();
  return <React.Fragment>{user.role === role ? children : ""}</React.Fragment>;
};

export default Authorize;
