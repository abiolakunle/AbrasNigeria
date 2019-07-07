import React from "react";

const TableItem = ({ item, index }) => {
  return (
    <React.Fragment>
      <tr>
        <th scope="row">{index + 1}</th>
        <td>{item.partNumber}</td>
        <td>{item.description}</td>
        <td>{(item.quantity * 1).toLocaleString()}</td>
        <td>{(item.unitPrice * 1).toLocaleString()}</td>
        <td>{(item.unitPrice * item.quantity).toLocaleString()}</td>
      </tr>
    </React.Fragment>
  );
};

export default TableItem;
