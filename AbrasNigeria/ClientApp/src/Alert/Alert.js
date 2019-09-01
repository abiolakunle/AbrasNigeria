import React from "react";
import { positions, Provider } from "react-alert";
import AlertTemplate from "react-alert-template-basic";

const options = {
  timeout: 5000,
  position: positions.BOTTOM_CENTER
};

const AlertProvider = ({ children }) => {
  return (
    <React.Fragment>
      <Provider template={AlertTemplate} {...options}>
        {children}
      </Provider>
    </React.Fragment>
  );
};

export default AlertProvider;
