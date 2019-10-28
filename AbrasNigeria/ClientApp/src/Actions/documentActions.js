import axios from "axios";

import { authHeader } from "../Helpers/authHeader";
import { request, success, failure } from "./requestStateActions";

import {
  CREATE_DOC_REQUEST,
  CREATE_DOC_SUCCESS,
  CREATE_DOC_FAILURE,
  UPDATE_DOC_REQUEST,
  UPDATE_DOC_SUCCESS,
  UPDATE_DOC_FAILURE,
  DELETE_DOC_REQUEST,
  DELETE_DOC_SUCCESS,
  DELETE_DOC_FAILURE,
  GET_DOC_REQUEST,
  GET_DOC_SUCCESS,
  GET_DOC_FAILURE,
  GET_DOCS_REQUEST,
  GET_DOCS_SUCCESS,
  GET_DOCS_FAILURE
} from "../Constants/documentConstants";

const requestOptions = {
  headers: authHeader()
};

export const createDocument = document => {
  console.log("Document", document);
  return dispatch => {
    dispatch(request(CREATE_DOC_REQUEST));

    axios
      .post("/api/document/create", document, requestOptions)
      .then(() => {
        dispatch(success(CREATE_DOC_SUCCESS, `created`));
      })
      .catch(({ message }) => {
        console.log(CREATE_DOC_FAILURE, message);
        dispatch(failure(CREATE_DOC_FAILURE, message));
      });
  };
};

export const updateDocument = document => {
  return dispatch => {
    dispatch(request(UPDATE_DOC_REQUEST));

    axios
      .post("/api/document/create", document, requestOptions)
      .then(() => {
        dispatch(success(UPDATE_DOC_SUCCESS, `updated`));
      })
      .catch(({ message }) => {
        console.log(UPDATE_DOC_FAILURE, message);
        dispatch(failure(UPDATE_DOC_FAILURE, message));
      });
  };
};

export const getDocuments = () => {
  return dispatch => {
    dispatch(request(GET_DOCS_REQUEST));
    axios
      .get("/api/document/documents", requestOptions)
      .then(({ data }) => {
        dispatch(success(GET_DOCS_SUCCESS, data));
      })
      .catch(error => {
        dispatch(failure(GET_DOCS_FAILURE, error));
        console.log(error);
      });
  };
};

export const getDocument = id => {
  return dispatch => {
    dispatch(request(GET_DOC_REQUEST));
    axios
      .get(`/api/document/document?id=${id}`, requestOptions)
      .then(({ data }) => {
        dispatch(success(GET_DOC_SUCCESS, data));
      })
      .catch(error => {
        dispatch(failure(GET_DOC_FAILURE, error));
        console.log(error);
      });
  };
};

export const deleteDocument = id => {
  return dispatch => {
    dispatch(request(DELETE_DOC_REQUEST));
    axios
      .delete(`/api/document/delete?id=${id}`, requestOptions)
      .then(({ data }) => {
        dispatch(success(DELETE_DOC_SUCCESS));
      })
      .catch(error => {
        dispatch(failure(DELETE_DOC_FAILURE, error));
        console.log(error);
      });
  };
};
