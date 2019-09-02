import {
  LOGIN_SUCCESS,
  LOGIN_REQUEST,
  LOGIN_FAILURE,
  REGISTER_REQUEST,
  REGISTER_SUCCESS,
  REGISTER_FAILURE
} from "../Constants/authConstants";

const initialState = {
  isRegistered: false,
  isRegistering: false,
  error: false,
  isLoggingIn: false,
  isLoggedIn: false
};

const authReducer = (state = initialState, action) => {
  switch (action.type) {
    case LOGIN_REQUEST:
      return {
        isLoggingIn: true
      };
    case LOGIN_SUCCESS:
      return {
        isLoggedIn: true,
        isLoggingIn: false
      };
    case LOGIN_FAILURE:
      return {
        error: true
      };
    case REGISTER_REQUEST:
      return {
        isRegistering: true
      };
    case REGISTER_SUCCESS:
      return {
        isRegistered: true,
        isRegistering: false
      };
    case REGISTER_FAILURE:
      return {
        error: true
      };
    default:
      return state;
  }
};

export default authReducer;
