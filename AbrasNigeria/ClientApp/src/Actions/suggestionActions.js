import axios from "axios";

import {
  PART_NO_SUGGESTIONS,
  DESCRIPTION_SUGGESTIONS,
  CATEGORY_SUGGESTIONS,
  MACHINE_SUGGESTIONS,
  CLEAR_PART_SUGGESTIONS
} from "../Constants/suggestionConstants";

export const suggestPartNumber = input => {
  return dispatch => {
    //load suggestions from server and update
    axios
      .get(
        `/api/product/search?searchQuery=${
          input //part number as search query
        }`
      )
      .then(response => {
        dispatch({
          type: PART_NO_SUGGESTIONS,
          payload: response.data
        });
      })
      .catch(error => {
        console.log("axios error", error);
      });
  };
};

export const clearPartNumberSuggestion = () => {
  return {
    type: CLEAR_PART_SUGGESTIONS
  };
};
