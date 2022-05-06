using MovieChallenge.Models;

namespace MovieChallenge.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetAsync(string id);
        Task CreateAsync(Movie movie);
        Task UpdateAsync(string id, Movie movie);
        Task DeleteAsync(string id);
    }
}
