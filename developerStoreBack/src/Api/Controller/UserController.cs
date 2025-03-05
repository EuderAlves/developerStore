using Microsoft.AspNetCore.Mvc;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Application.Services;
using System;
using DeveloperStoreBack.Domain.Entities;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            try
            {
                var registeredUser = await _userService.Register(userDto);
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
                return Unauthorized(new { Message = "Email ou senha inválidos." });
            }

            return Ok(new { Message = "Login bem-sucedido!" });
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "Usuário não encontrado." });
            }

            await _userService.DeleteUser(id);
            return Ok(new { Message = "Usuário deletado com sucesso." });
        }
    }
}