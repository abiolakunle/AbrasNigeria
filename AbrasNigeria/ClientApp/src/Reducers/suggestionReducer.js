import {
  PART_NO_SUGGESTIONS,
  CLEAR_PART_SUGGESTIONS
} from "../Constants/suggestionConstants";

const initialState = { partNoSuggestions: [] };

const suggestionReducer = (state = initialState, action) => {
  switch (action.type) {
    case PART_NO_SUGGESTIONS:
      return {
        ...state,
        partNoSuggestions: action.payload
      };
    case CLEAR_PART_SUGGESTIONS:
      return {
        ...state,
        partNoSuggestions: []
      };
    default:
      return { ...state };
  }
};

export default suggestionReducer;
