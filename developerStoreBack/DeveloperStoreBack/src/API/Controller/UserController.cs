using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Application.Dtos
{ 
[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase

{
    private readonly MongoDbContext _context;
    public UserController(MongoDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.PasswordHash))
        {
            return BadRequest("Usuário inválido.");
        }

        user.PasswordHash = HashPassword(user.PasswordHash);
        await _context.Users.InsertOneAsync(user);

        return CreatedAtAction(nameof(Register), new { id = user.Id }, user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
    {
        var existingUser = await _context.Users
            .Find(u => u.Email == userDto.Email)
            .FirstOrDefaultAsync();

        if (existingUser == null || !VerifyPassword(userDto.PasswordHash, existingUser.PasswordHash))
        {
            return Unauthorized("Email ou senha inválidos.");
        }

        return Ok("Login bem-sucedido!");
    }

    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

    private bool VerifyPassword(string password, string storedHash)
    {
        var hash = HashPassword(password);
        return hash == storedHash;
    }
}
}
