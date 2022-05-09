using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using MovieChallenge.Api.Models;
using MovieChallenge.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieChallenge.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _user;
        private readonly string JWT_KEY = null;

        public UserService(IConfigurationSettings configurationSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(configurationSettings.DatabaseName);
            _user = database.GetCollection<User>(Constants.USER_COLLECTION);
            JWT_KEY = configurationSettings.JwtKey;
        }

        public string Authenticate(string email, string password)
        {
            var user = _user.Find(u => u.Email == email && u.Password == password).FirstOrDefault();

            if (user is null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(JWT_KEY);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),

                Expires = DateTime.UtcNow.AddMinutes(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task CreateAsync(User user) => await _user.InsertOneAsync(user);

        public async Task DeleteAsync(string id) => await _user.DeleteOneAsync(m => m.Id == id);

        public async Task<List<User>> GetAllAsync() => await _user.Find(u => true).ToListAsync();

        public async Task<User?> GetAsync(string id) => await _user.Find(u => u.Id == id).FirstOrDefaultAsync();

        public async Task UpdateAsync(string id, User user) => await _user.ReplaceOneAsync(u => u.Id == id, user);
    }
}
