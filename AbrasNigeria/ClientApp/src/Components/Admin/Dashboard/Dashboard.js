import React from "react";
import SideNavbar from "../Shared/SideNavbar";
import userService from "../../../Services/userService";

const Dashboard = () => {
  const { userName } = userService.getCurrentUser();
  return (
    <SideNavbar>
      <React.Fragment>Welcome {userName}</React.Fragment>
    </SideNavbar>
  );
};

export default Dashboard;
