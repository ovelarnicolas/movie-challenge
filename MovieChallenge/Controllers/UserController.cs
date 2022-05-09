using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieChallenge.Api.Models;
using MovieChallenge.Api.Services;

namespace MovieChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) => _userService = userService;

        [HttpGet]
        public async Task<List<User>> Get() => await _userService.GetAllAsync();

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _userService.GetAsync(id);

            if (user == null) return NotFound();

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _userService.CreateAsync(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, User updateUser)
        {
            var user = await _userService.GetAsync(id);

            if (user is null) return NotFound();

            user.Id = user.Id;

            await _userService.UpdateAsync(id, updateUser);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetAsync(id);

            if (user is null) return NotFound();

            await _userService.DeleteAsync(id);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email)) return BadRequest("Email is mandatory.");

            if (string.IsNullOrEmpty(request.Password)) return BadRequest("Password is mandatory.");

            var token = _userService.Authenticate(request.Email, request.Password);

            if (token is null) return Unauthorized();

            return Ok(new { email = request.Email, token });
        }
    }
}