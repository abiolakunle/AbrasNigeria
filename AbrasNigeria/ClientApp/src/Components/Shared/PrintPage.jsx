import React from "react";

const PrintPage = ({ children, id }) => {
  return (
    <React.Fragment>
      <div id={id}>{children}</div>
    </React.Fragment>
  );
};

export default PrintPage;
