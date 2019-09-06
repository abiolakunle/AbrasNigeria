import React from "react";

const PrintPage = ({ children, singleMode, id }) => {
  return (
    <div id={id}>{children}</div>
    //     <div id={id} style={{ width: "210mm", height: singleMode ? "297mm" : "" }}>
    //     {children}
    //   </div>
  );
};

export default PrintPage;
