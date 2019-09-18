import React from "react";
import RouteTitle from "./RouteTitle";

const WithTitle = props => {
  const { compnent: Component, title } = props;
  return (
    <React.Fragment>
      <RouteTitle title={title} />
      <Component />
    </React.Fragment>
  );
};

export default WithTitle;
