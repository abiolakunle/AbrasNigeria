export const authHeader = () => {
  let user = JSON.parse(localStorage.getItem("usesr"));

  if (user && user.token) {
    return { Authorization: "Bearer" + user.token };
  } else {
    return {};
  }
};
