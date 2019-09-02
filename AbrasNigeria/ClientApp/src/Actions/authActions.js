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

    userService
      .login(username, password)
      .then(({ data }) => {
        localStorage.setItem("user", JSON.stringify(data));
        console.log("LOGINED", data);
        dispatch(success());
      })
      .catch(error => {
        dispatch(failure());
        console.error("Login error", error);
      });
  };
};

export const register = user => {
  const request = () => {
    return { type: REGISTER_REQUEST };
  };

  const success = () => {
    return { type: REGISTER_SUCCESS };
  };

  const failure = () => {
    return { type: REGISTER_FAILURE };
  };

  return dispatch => {
    dispatch(request());

    userService
      .register(user)
      .then(response => {
        dispatch(success());
        console.log("register", response);
      })
      .catch(error => {
        dispatch(failure());
        console.error("register error", error);
      });
  };
};

export const logout = () => {
  userService.logout();
};
