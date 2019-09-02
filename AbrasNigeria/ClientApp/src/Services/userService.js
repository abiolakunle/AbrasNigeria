import axios from "axios";

import { authHeader } from "../Helpers/authHeader";

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

const logout = () => {
  localStorage.removeItem("user");
  window.location.reload(true);
};

export const userService = {
  login,
  register,
  logout
};
