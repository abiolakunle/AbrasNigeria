import { CREATE_DOCUMENT } from "../Constants/documentConstants";

const initialState = {
  documentCreated: false
};

const documentReducer = (state = initialState, action) => {
  switch (action.type) {
    case CREATE_DOCUMENT:
      return {
        ...state,
        documentCreated: action.payload
      };
    default:
      return state;
  }
};

export default documentReducer;
