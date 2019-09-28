import axios from "axios";

import { authHeader } from "../Helpers/authHeader";

import {
  CREATE_DOC_REQUEST,
  CREATE_DOC_SUCCESS,
  CREATE_DOC_FAILURE,
  UPDATE_DOC_REQUEST,
  UPDATE_DOC_SUCCESS,
  UPDATE_DOC_FAILURE,
  GET_DOC_REQUEST,
  GET_DOC_SUCCESS,
  GET_DOC_FAILURE,
  GET_DOCS_REQUEST,
  GET_DOCS_SUCCESS,
  GET_DOCS_FAILURE
} from "../Constants/documentConstants";

const requestOptions = {
  method: "POST",
  headers: authHeader()
};

export const createDocument = document => {
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

  return dispatch => {
    dispatch(request());

    axios
      .post("/api/document/createdocument", document, requestOptions)
      .then(() => {
        dispatch(success(`created`));
      })
      .catch(({ message }) => {
        console.log(CREATE_DOC_FAILURE, message);
        dispatch(failure(message));
      });
  };
};

export const updateDocument = document => {
  const request = () => {
    return {
      type: UPDATE_DOC_REQUEST
    };
  };

  const success = message => {
    return {
      type: UPDATE_DOC_SUCCESS,
      payload: message
    };
  };

  const failure = messsage => {
    return {
      type: UPDATE_DOC_FAILURE,
      payload: messsage
    };
  };

  return dispatch => {
    dispatch(request());

    axios
      .post("/api/document/createdocument", document, requestOptions)
      .then(() => {
        dispatch(success(`updated`));
      })
      .catch(({ message }) => {
        console.log(UPDATE_DOC_FAILURE, message);
        dispatch(failure(message));
      });
  };
};

export const getDocuments = () => {
  const request = () => {
    return {
      type: GET_DOCS_REQUEST
    };
  };

  const success = data => {
    return {
      type: GET_DOCS_SUCCESS,
      payload: data
    };
  };

  const failure = messsage => {
    return {
      type: GET_DOCS_FAILURE,
      payload: messsage
    };
  };

  return dispatch => {
    dispatch(request());
    axios
      .get("/api/document/documents", requestOptions)
      .then(({ data }) => {
        dispatch(success(data));
      })
      .catch(error => {
        dispatch(failure(error));
        console.log(error);
      });
  };
};

export const getDocument = id => {
  const request = () => {
    return {
      type: GET_DOC_REQUEST
    };
  };

  const success = data => {
    return {
      type: GET_DOC_SUCCESS,
      payload: data
    };
  };

  const failure = messsage => {
    return {
      type: GET_DOC_FAILURE,
      payload: messsage
    };
  };

  return dispatch => {
    dispatch(request());
    axios
      .get(`/api/document/document?id=${id}`, requestOptions)
      .then(({ data }) => {
        dispatch(success(data));
      })
      .catch(error => {
        dispatch(failure(error));
        console.log(error);
      });
  };
};
