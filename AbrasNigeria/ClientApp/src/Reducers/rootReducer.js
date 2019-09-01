import { combineReducers } from "redux";

import documentReducer from "./documentReducer";
import suggestionReducer from "./suggestionReducer";
import authReducer from "./authReducer";

const rootReducer = combineReducers({
  suggestionReducer,
  documentReducer,
  authReducer
});

export default rootReducer;
