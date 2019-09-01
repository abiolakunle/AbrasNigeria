import {
  LOGIN_SUCCESS,
  LOGIN_REQUEST,
  LOGIN_FAILURE
} from "../Constants/authConstants";

const initialState = {};

const authReducer = (state = initialState, action) => {
  switch (action) {
    case LOGIN_REQUEST:
      return state;
    case LOGIN_SUCCESS:
      return state;
    case LOGIN_FAILURE:
      return state;
    default:
      return state;
  }
};

export default authReducer;
