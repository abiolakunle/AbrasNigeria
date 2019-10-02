import { combineReducers } from "redux";

import documentReducer from "./documentReducer";
import suggestionReducer from "./suggestionReducer";
import authReducer from "./authReducer";
import stockReducer from "./stockReducer";

const rootReducer = combineReducers({
  suggestionReducer,
  documentReducer,
  authReducer,
  stockReducer
});

export default rootReducer;
