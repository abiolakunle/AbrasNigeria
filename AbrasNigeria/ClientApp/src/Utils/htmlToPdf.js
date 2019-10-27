import html2Pdf from "html2pdf.js";

const getDefaultOption = id => {
  return {
    margin: 0,
    filename: `${id}.pdf`,
    image: { type: "jpeg", quality: 0.98 },
    html2canvas: { scale: 2 },
    jsPDF: { unit: "pt", format: "a4", orientation: "portrait" }
  };
};

const sourceReference = source => {
  return html2Pdf().from(source);
};

export const createPdfFile = id => {
  const source = document.getElementById(id);

  const opt = getDefaultOption(id);

  return sourceReference(source)
    .set(opt)
    .outputPdf();
};

export const downloadPdf = id => {
  const source = document.getElementById(id);
  const opt = getDefaultOption(id);

  sourceReference(source)
    .set(opt)
    .save();
};
