import axios from "axios";
import { request, success, failure } from "./requestStateActions";
import { authHeader } from "../Helpers/authHeader";

import {
  CREATE_STOCK_REQUEST,
  CREATE_STOCK_SUCCESS,
  CREATE_STOCK_FAILURE,
  GET_STOCK_REQUEST,
  GET_STOCK_SUCCESS,
  GET_STOCK_FAILURE
} from "../Constants/stockConstants";

const requestOptions = {
  headers: { ...authHeader(), "Content-Type": "application/json" }
};

export const getStock = () => {
  return dispatch => {
    const api = "/api/stock/products";
    dispatch(request(GET_STOCK_REQUEST));
    axios
      .get(api, requestOptions)
      .then(({ data }) => {
        dispatch(success(GET_STOCK_SUCCESS, data));
        console.log("data", data);
      })
      .catch(({ message }) => {
        dispatch(failure(GET_STOCK_FAILURE, message));
        console.error("axios error", message);
      });
  };
};
