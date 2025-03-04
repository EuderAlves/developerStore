using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Application.DTOs;
using DeveloperStoreBack.Domain.Repositories;
using MongoDB.Driver;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStoreBack.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Register(UserRegisterDto userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.PasswordHash) || string.IsNullOrEmpty(userDto.CompanyName))
            {
                throw new ArgumentException("Usuário inválido.");
            }

            var existingUser = await _userRepository.GetUserByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("O e-mail já está em uso.");
            }

            var user = new User
            {
                Email = userDto.Email,
                PasswordHash = HashPassword(userDto.PasswordHash),
                Name = userDto.Name,
                CompanyName = userDto.CompanyName,
                UserType = userDto.UserType
            };

            await _userRepository.InsertAsync(user);
            return user;
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado.");
            }

            await _userRepository.DeleteAsync(id); 
        }

        public async Task<bool> Login(UserLoginDto userLoginDto)
        {
            if (userLoginDto == null || string.IsNullOrEmpty(userLoginDto.Email) || string.IsNullOrEmpty(userLoginDto.PasswordHash))
            {
                throw new ArgumentException("Credenciais inválidas.");
            }

            var user = await _userRepository.GetUserByIdAsync(userLoginDto.Email);

            if (user == null)
            {
                return false;
            }

            return VerifyPassword(userLoginDto.PasswordHash, user.PasswordHash);
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