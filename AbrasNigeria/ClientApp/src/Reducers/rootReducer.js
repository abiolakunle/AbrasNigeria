import { combineReducers } from "redux";

import documentReducer from "./documentReducer";
import suggestionReducer from "./suggestionReducer";

const rootReducer = combineReducers({ suggestionReducer, documentReducer });

export default rootReducer;
