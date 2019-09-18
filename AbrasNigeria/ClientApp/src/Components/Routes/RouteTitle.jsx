import React from "react";
import Helmet from "react-helmet";

const RouteTitle = ({ title }) => {
  return (
    <Helmet>
      <title>Abras Nigeria - {title}</title>
    </Helmet>
  );
};

export default RouteTitle;
