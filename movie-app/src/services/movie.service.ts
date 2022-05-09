import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:7071/api/";

export const getPublicContent = () => {
  return axios.get(API_URL);
};

export const getUserMovies = () => {
  return axios.get(API_URL + "movie", { headers: authHeader() });
};
