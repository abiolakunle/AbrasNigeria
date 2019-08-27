import axios from "axios";
import {
  CREATE_DOCUMENT,
  DOC_SUCCESS,
  DOC_ERRROR
} from "../Constants/documentConstants";

export const createDocument = document => {
  return dispatch => {
    console.log("New Invoice", document);
    axios
      .post("/api/document/createdocument", document)
      .then(response => {
        dispatch({
          type: DOC_SUCCESS,
          payload: true
        });
      })
      .catch(error => {
        console.log(error);
        dispatch({
          type: DOC_ERRROR,
          payload: error
        });
      });
  };
};
