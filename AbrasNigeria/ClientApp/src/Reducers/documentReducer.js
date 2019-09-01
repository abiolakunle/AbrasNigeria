import {
  CREATE_DOC_SUCCESS,
  CREATE_DOC_FAILURE,
  CREATE_DOC_REQUEST
} from "../Constants/documentConstants";

const initialState = {
  isCreating: false,
  isCreated: false,
  error: false,
  message: null
};

const documentReducer = (state = initialState, action) => {
  switch (action.type) {
    case CREATE_DOC_REQUEST:
      return {
        ...state,
        isCreating: true,
        isCreated: false
      };
    case CREATE_DOC_SUCCESS:
      return {
        ...state,
        isCreating: false,
        isCreated: true,
        message: action.payload
      };
    case CREATE_DOC_FAILURE:
      return {
        ...state,
        isCreating: false,
        isCreated: false,
        error: true,
        message: action.payload
      };
    default:
      return state;
  }
};

export default documentReducer;
