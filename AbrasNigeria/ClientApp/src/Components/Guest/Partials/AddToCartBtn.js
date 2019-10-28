import React from "react";
import { CartConsumer } from "../../../Contexts/CartContext";

const AddToCartBtn = props => {
  const { product } = props;
  const { partNumber, descriptions } = product;

  return (
    <CartConsumer>
      {contextValue => {
        const { syncWithCart, addToCart } = contextValue;
        return (
          <div>
            {!syncWithCart(partNumber) ? (
              <button
                className="btn btn-light badge badge-pill p-2"
                role="link"
                onClick={() => {
                  addToCart({ partNumber, descriptions, quantity: 1 });
                }}
              >
                Add to cart <span className="fas fa-plus-circle" />
              </button>
            ) : (
              <button
                className="btn btn-light badge badge-pill p-2"
                role="link"
                onClick={() => {
                  addToCart({ partNumber });
                }}
              >
                Remove from cart <span className="fas fa-minus-circle" />
              </button>
            )}
          </div>
        );
      }}
    </CartConsumer>
  );
};

export default AddToCartBtn;
