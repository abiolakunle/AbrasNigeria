export const request = type => {
  return {
    type
  };
};

export const success = (type, message) => {
  return {
    type,
    payload: message
  };
};

export const failure = (type, messsage) => {
  return {
    type,
    payload: messsage
  };
};
