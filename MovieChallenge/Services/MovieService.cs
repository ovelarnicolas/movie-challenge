using MovieChallenge.Models;
using MongoDB.Driver;
using MovieChallenge.Api.Models;

namespace MovieChallenge.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieService(IConfigurationSettings configurationSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(configurationSettings.DatabaseName);
            _movies = database.GetCollection<Movie>(Constants.MOVIE_COLLECTION);
        }

        public async Task CreateAsync(Movie movie) => await _movies.InsertOneAsync(movie);

        public async Task DeleteAsync(string id) => await _movies.DeleteOneAsync(m => m.Id == id);

        public async Task<List<Movie>> GetAllAsync() => await _movies.Find(m => true).ToListAsync();

        public async Task<Movie?> GetAsync(string id) => await _movies.Find(m => m.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, Movie movie) => await _movies.ReplaceOneAsync(m => m.Id == id, movie);
    }
}
