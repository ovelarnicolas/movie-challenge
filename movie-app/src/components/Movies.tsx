import React, { useEffect } from "react";
import { Movie } from "../models/movies";
import { getUserMovies } from "../services/movie.service";

function App() {
  const [movies, setmovies] = React.useState<Movie[]>([]);

  useEffect(() => {
    getUserMovies().then((response) => setmovies(response.data));
  }, []);

  return (
    <>
      <h2>This are movies authorized by JWT:</h2>
      {movies.map((movie) => (
        <div>
          <h4>{movie.title}</h4>
          <p>Plot: {movie.plot}</p>
          <p>Year: {movie.year}</p>
          <label>{new Date(movie.released).toDateString()}</label>
        </div>
      ))}
    </>
  );
}

export default App;
