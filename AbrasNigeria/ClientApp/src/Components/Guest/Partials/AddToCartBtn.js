import React from "react";
import { CartConsumer } from "../../../Contexts/CartContext";

export default function AddToCartBtn(props) {
  console.log(props);
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
                    partNumber: product.partNumber,
                    category: product.category,
                    quantity: 1
                  });
                }}
              >
                Add to cart <span class="fas fa-plus-circle" />
              </button>
            ) : (
              <button
                className="btn btn-light badge badge-pill p-2"
                role="link"
                onClick={() => {
                  addToCart({
                    partNumber: product.partNumber,
                    category: product.category
                  });
                }}
              >
                Remove from cart <span class="fas fa-minus-circle" />
              </button>
            )}
          </div>
        );
      }}
    </CartConsumer>
  );
}
