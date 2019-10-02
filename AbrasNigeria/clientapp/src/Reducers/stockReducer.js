import {
  CREATE_STOCK_REQUEST,
  CREATE_STOCK_SUCCESS,
  CREATE_STOCK_FAILURE,
  GET_STOCK_REQUEST,
  GET_STOCK_SUCCESS,
  GET_STOCK_FAILURE
} from "../Constants/stockConstants";
import { GET_DOCS_FAILURE } from "../Constants/documentConstants";

const intialState = {
  isLoading: false,
  isLoaded: false,
  stockItems: [],
  error: false
};

const stockReducer = (state = intialState, action) => {
  console.log("action type", action.type);
  switch (action.type) {
    case GET_STOCK_REQUEST:
      return {
        ...state,
        isLoading: true,
        isLoaded: false
      };
    case GET_STOCK_SUCCESS:
      return {
        ...state,
        isLoading: false,
        isLoaded: true,
        stockItems: action.payload
      };
    case GET_STOCK_FAILURE:
      return {
        ...state,
        isLoading: false,
        isLoaded: false,
        error: true,
        message: action.payload
      };
    default:
      return state;
  }
};

export default stockReducer;
