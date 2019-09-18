import React from "react";

import GuestHeader from "./GuestHeader";
import GuestFooter from "./GuestFooter";

import CartProvider from "../../../Contexts/CartContext";

const HeaderFooter = ({ children }) => {
  return (
    <CartProvider>
      <React.Fragment>
        <GuestHeader />
        <main className="container py-5">{children}</main>
        <GuestFooter />
      </React.Fragment>
    </CartProvider>
  );
};

export default HeaderFooter;
