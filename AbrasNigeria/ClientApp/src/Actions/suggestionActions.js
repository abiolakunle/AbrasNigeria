import axios from "axios";

import {
  PART_NO_SUGGESTIONS,
  CLEAR_PART_SUGGESTIONS
} from "../Constants/suggestionConstants";

const CancelToken = axios.CancelToken;
let cancel;

export const suggestPartNumber = input => {
  return dispatch => {
    //load suggestions from server and update
    cancel && cancel("Search overriden");

    axios
      .get(`/api/product/search?searchQuery=${input}`, {
        cancelToken: new CancelToken(c => {
          cancel = c;
        })
      })
      .then(response => {
        dispatch({ type: PART_NO_SUGGESTIONS, payload: response.data });
      })
      .catch(error => {
        if (axios.isCancel(error)) console.log("axios error", error);
      });
  };
};

export const clearPartNumberSuggestion = () => {
  return {
    type: CLEAR_PART_SUGGESTIONS
  };
};
