export const request = type => {
  return {
    type
  };
};

export const success = (type, message = "Successful") => {
  return {
    type,
    payload: message
  };
};

export const failure = (type, messsage = "Failed") => {
  return {
    type,
    payload: messsage
  };
};
