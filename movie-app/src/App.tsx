import React, { useEffect } from "react";
// import logo from "./logo.svg";
import "./App.css";
import axios, { AxiosResponse } from "axios";
import { Movie } from "./models/movies";
import { format } from "date-fns";

function App() {
  const [movies, setmovies] = React.useState<Movie[]>([]);

  useEffect(() => {
    axios
      .get("https://localhost:7071/api/Movie")
      .then((response: AxiosResponse<Movie[]>) => {
        console.log(response.data);
        setmovies(response.data);
      });
  }, []);

  return (
    <>
      <h1>Movie Challenge React App</h1>
      <h2>Movies:</h2>
      {movies.map((movie) => (
        <div>
          <h1>{movie.title}</h1>
          <p>Plot: {movie.plot}</p>
          <p>Year: {movie.year}</p>
          <label>{new Date(movie.released).toDateString()}</label>
        </div>
      ))}
    </>
  );
}

export default App;
