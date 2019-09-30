import axios from "axios";

import { authHeader } from "../Helpers/authHeader";
import { USER } from "../Constants/localStorageKeyConstants";
import { ADMIN, GUEST, SUPER_ADMIN } from "../Constants/rolesConstants";

const login = user => {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" }
  };

  return axios.post("/api/user/authenticate", { ...user }, requestOptions);
};

const register = user => {
  const requestOptions = {
    method: "PUT",
    headers: { ...authHeader(), "Content-Type": "application/json" }
  };

  return axios.put("/api/user/register", { ...user }, requestOptions);
};

const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem(USER));
};

const logout = () => {
  localStorage.removeItem(USER);
  window.location.reload(true);
};

const roles = {
  GUEST,
  ADMIN,
  SUPER_ADMIN
};

export default {
  login,
  register,
  getCurrentUser,
  roles,
  logout
};
