import React from "react";

const PrintPageArea = ({ children, id }) => {
  return (
    <React.Fragment>
      <div id={id}>{children}</div>
    </React.Fragment>
  );
};

export default PrintPageArea;
