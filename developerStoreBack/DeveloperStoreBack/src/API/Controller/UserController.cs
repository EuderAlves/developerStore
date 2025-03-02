using Microsoft.AspNetCore.Mvc;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Application.Services;
using DeveloperStoreBack.Domain.Entities;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            try
            {
                var registeredUser = await _userService.Register(user);
                return CreatedAtAction(nameof(Register), new { id = registeredUser.Id }, registeredUser);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            var isLoginSuccessful = await _userService.Login(userDto);
            if (!isLoginSuccessful)
            {
                return Unauthorized("Email ou senha inválidos.");
            }

            return Ok("Login bem-sucedido!");
        }
    }
}