const dataStringToUintArray = binString => {
  const base64 = btoa(binString); //btoa() function creates a base-64 encoded ASCII string from a "string" of binary data.
  const bstr = atob(base64); //The atob() function decodes a string of data which has been encoded using base-64 encoding

  let n = bstr.length;
  const u8arr = new Uint8Array(n);
  while (n--) {
    u8arr[n] = bstr.charCodeAt(n);
  }
  return u8arr;
};

export default dataStringToUintArray;
