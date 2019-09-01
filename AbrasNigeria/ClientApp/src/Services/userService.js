import axios from "axios";

import { authHeader } from "../Helpers/authHeader";

const login = (username, password) => {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ username, password })
  };

  return axios
    .get("/api/user/authenticate", requestOptions)
    .then(response => {
      localStorage.setItem("user", JSON.stringify(response));
      console.log("login", response);
      return response;
    })
    .catch(error => {
      console.error("Login error", error);
    });
};

const register = user => {
  const requestOptions = {
    method: "PUT",
    headers: { ...authHeader(), "Content-Type": "application/json" },
    body: JSON.stringify(user),
    url: "/api/user/register"
  };

  console.log(requestOptions);
  axios
    .put("/api/user/register", { ...user })
    .then(response => {
      console.log("register", response);
    })
    .catch(error => {
      console.error("register error", error);
    });
};

export const userService = {
  login,
  register
};
