import React from "react";
import { CartConsumer } from "../../../Contexts/CartContext";

const AddToCartBtn = props => {
  const { product } = props;

  return (
    <CartConsumer>
      {contextValue => {
        const { syncWithCart, addToCart } = contextValue;
        return (
          <div>
            {!syncWithCart(product.partNumber) ? (
              <button
                className="btn btn-light badge badge-pill p-2"
                role="link"
                onClick={() => {
                  addToCart({
                    productId: product.productId,
                    partNumber: product.partNumber,
                    categories: product.categories,
                    quantity: 1
                  });
                }}
              >
                Add to cart <span className="fas fa-plus-circle" />
              </button>
            ) : (
              <button
                className="btn btn-light badge badge-pill p-2"
                role="link"
                onClick={() => {
                  addToCart({
                    partNumber: product.partNumber,
                    categories: product.categories
                  });
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
