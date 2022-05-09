import { AxiosRequestHeaders } from "axios";

export default function authHeader() {
  const userStr = localStorage.getItem("user");
  let user = null;
  if (userStr) user = JSON.parse(userStr);

  if (user && user.token) {
    let headers: AxiosRequestHeaders = {
      "Content-Type": "application/json",
      Authorization: "Bearer " + user.token,
    };

    return headers;
  } else {
    return {};
  }
}
