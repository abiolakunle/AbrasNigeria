import React from "react";
import { downloadPdf } from "../../Utils/htmlToPdf";

const PrintBtn = ({ id, label }) => {
  return (
    <button
      className="btn text-white grey darken-2"
      onClick={() => downloadPdf(id)}
    >
      {label}
    </button>
  );
};

export default PrintBtn;
