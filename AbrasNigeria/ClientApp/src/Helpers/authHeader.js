import userService from "../Services/userService";

export const authHeader = () => {
  let user = userService.getCurrentUser();

  if (user && user.tokenString) {
    return { Authorization: "Bearer " + user.tokenString };
  } else {
    return {};
  }
};
