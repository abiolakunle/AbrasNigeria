import axios from "axios";

import {
  CREATE_DOC_REQUEST,
  CREATE_DOC_SUCCESS,
  CREATE_DOC_FAILURE
} from "../Constants/documentConstants";

export const createDocument = document => {
  return dispatch => {
    dispatch(request());
    axios
      .post("/api/document/createdocument", document)
      .then(() => {
        dispatch(success(`created`));
      })
      .catch(({ message }) => {
        console.log(CREATE_DOC_FAILURE, message);
        dispatch(failure(message));
      });
  };
};

const request = () => {
  return {
    type: CREATE_DOC_REQUEST
  };
};

const success = message => {
  return {
    type: CREATE_DOC_SUCCESS,
    payload: message
  };
};

const failure = messsage => {
  return {
    type: CREATE_DOC_FAILURE,
    payload: messsage
  };
};
