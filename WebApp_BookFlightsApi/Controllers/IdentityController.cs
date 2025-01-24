using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using WebApp_BookFlightsApi.Domain.Identity.Interfaces;
using WebApp_BookFlightsApi.Domain.Identity.Models;

namespace WebApp_BookFlightsApi.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly IUserService _userService;

        public IdentityController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet("auth")]
        public IActionResult Test()
        {
            return Ok($"Авторизован: {User.Identity.IsAuthenticated} {User.Claims.ToList()}");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegistrationDto request)
        {
            var result = await _userService.Register(request);

            return Ok(result);
        }

        [HttpPost("updateById")]
        public async Task<IActionResult> UpdateById(UpdateUserDto request)
        {
            var result = await _userService.UpdateUserById(request);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var result = await _userService.Login(request);

            return Ok(result);
        }

        [HttpGet("getUserByEmail")]
        public IActionResult GetUserByEmail(string email)
        {
            var result = _userService.GetUserByEmail(email);

            return Ok(result);
        }

        [HttpGet("getUserById")]
        public IActionResult GetUserById(long? userId)
        {
            var result = _userService.GetUserById(userId);

            return Ok(result);
        }
    }
}
