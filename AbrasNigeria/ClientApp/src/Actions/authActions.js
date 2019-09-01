import { userService } from "../Services/userService";
import {
  LOGIN_REQUEST,
  LOGIN_SUCCESS,
  LOGIN_FAILURE,
  REGISTER_REQUEST,
  REGISTER_SUCCESS,
  REGISTER_FAILURE
} from "../Constants/authConstants";

export const login = (username, password) => {
  const request = () => {
    return { type: LOGIN_REQUEST };
  };

  const success = () => {
    return { type: LOGIN_SUCCESS };
  };

  const failure = () => {
    return { type: LOGIN_FAILURE };
  };

  return dispatch => {
    dispatch(request());

    userService.login(username, password);
  };
};

export const register = (username, password) => {
  const request = () => {
    return { type: LOGIN_REQUEST };
  };

  const success = () => {
    return { type: LOGIN_SUCCESS };
  };

  const failure = () => {
    return { type: LOGIN_FAILURE };
  };

  return dispatch => {
    dispatch(request());

    userService.register({ username, password });
  };
};
