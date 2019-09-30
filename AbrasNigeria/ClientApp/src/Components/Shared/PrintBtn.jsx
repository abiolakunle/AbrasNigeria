import React from "react";
import html2Pdf from "html2pdf.js";

const PrintBtn = ({ id, label }) => {
  return (
    <div className="">
      <button
        className="btn text-white grey darken-2"
        onClick={() => htmlToPdf(id)}
      >
        {label}
      </button>
    </div>
  );
};

const htmlToPdf = id => {
  const source = document.getElementById(id);

  const opt = {
    margin: 0,
    filename: `${id}.pdf`,
    image: { type: "jpeg", quality: 0.98 },
    html2canvas: { scale: 2 },
    jsPDF: { unit: "pt", format: "a4", orientation: "portrait" }
  };

  html2Pdf()
    .from(source)
    .set(opt)
    .save();
};

export default PrintBtn;
