import { Movie } from "../models/movies";

export default interface IUser {
  id?: string | null;
  email: string;
  password: string;
  movies?: Array<Movie>;
}
