import React from "react";
import html2canvas from "html2canvas";
import jsPDF from "jspdf";
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

const js2Pdf = id => {
  const input = document.getElementById(id);

  const offsetWidth = input.offsetWidth;
  const offsetHeight = input.offsetHeight;

  const a4WidthMm = 210;
  const a4HeightMm = 297;
  const a4Ratio = a4WidthMm / a4HeightMm;

  // const numPages =
  //   inputHeightMm <= a4HeightMm
  //     ? 1
  //     : Math.ceil(inputHeightMm / a4HeightMm);

  let newPdf = new jsPDF("p", "pt", "a4");
  newPdf.fromHTML(input);
  newPdf.save(`${id}.pdf`);

  // html2canvas(input, { dpi: 300, scale: 3, allowTaint: true }).then(
  //   canvas => {
  //     const imgData = canvas.toDataURL("image/jpeg");

  //     // const cWidth = canvas.width;
  //     // const cHeight = canvas.height;
  //     const cWidth = offsetWidth;
  //     const cHeight = offsetHeight;

  //     const pageWidth = (cWidth * 4) / 5;
  //     const pageHeight = cWidth / a4Ratio - cWidth / a4Ratio / 5;
  //     const marginX = ((cWidth * 4) / 5 - (cWidth * 3) / 4) / 2;

  //     const totalPages = Math.ceil(cHeight / pageHeight);

  //     let pdf;

  //     // elongated a4 (system print dialog will handle page breaks)
  //     pdf = new jsPDF("portrait", "px", [pageWidth, pageHeight]);
  //     pdf.addImage(imgData, "JPG", marginX, 0);

  //     for (var i = 1; i < totalPages; i++) {
  //       pdf.addPage([pageWidth, pageHeight], "p");
  //       pdf.addImage(
  //         imgData,
  //         "JPG",
  //         marginX,
  //         -pageHeight + (pageHeight / 4) * i
  //       );
  //     }

  //     pdf.save(`${id}.pdf`);
  //   }
  // );

  ////////////////////////////////////////////////////////
  // System to manually handle page breaks
  // Wasn't able to get it working !
  // The idea is to break html2canvas screenshots into multiple chunks and stich them together as a pdf
  // If you get this working, please email me a khuranashivek@outlook.com and I'll update the article
  ////////////////////////////////////////////////////////
  // range(0, numPages).forEach((page) => {
  //   console.log(`Rendering page ${page}. Capturing height: ${a4HeightPx} at yOffset: ${page*a4HeightPx}`);
  //   html2canvas(input, {height: a4HeightPx, y: page*a4HeightPx})
  //     .then((canvas) => {
  //       const imgData = canvas.toDataURL('image/png');
  //       console.log(imgData)
  //       if (page > 0) {
  //         pdf.addPage();
  //       }
  //       pdf.addImage(imgData, 'PNG', 0, 0);
  //     });
  //   ;
  // });

  // setTimeout(() => {
  //   pdf.save(`${id}.pdf`);
  // }, 5000);
};

export default PrintBtn;
