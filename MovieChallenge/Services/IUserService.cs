using MovieChallenge.Api.Models;

namespace MovieChallenge.Api.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetAsync(string id);
        Task CreateAsync(User user);
        Task UpdateAsync(string id, User user);
        Task DeleteAsync(string id);
        string Authenticate(string email, string password);
    }
}
