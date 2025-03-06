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

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return false;
            }

            await _userRepository.DeleteAsync(id);
            return true;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<bool> Login(UserLoginDto userLoginDto)
        {
            if (userLoginDto == null || string.IsNullOrEmpty(userLoginDto.Email) || string.IsNullOrEmpty(userLoginDto.PasswordHash))
            {
                throw new ArgumentException("Credenciais inválidas.");
            }

            var user = await _userRepository.GetUserByEmailAsync(userLoginDto.Email);

            if (user == null)
            {
                return false;
            }

            return VerifyPassword(userLoginDto.PasswordHash, user.PasswordHash);
        }

        public async Task<UserDataDto> GetUserDataByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserDataByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            var userData = new UserDataDto
            {
                Id = new IdDto
                {
                    Timestamp = user.Id.Timestamp,
                    CreationTime = user.Id.CreationTime,
                },
                Email = user.Email,
                Name = user.Name,
                CompanyName = user.CompanyName,
                UserType = user.UserType
            };
            return userData;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return users.Select(user => new UserDto
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Name = user.Name,
                CompanyName = user.CompanyName,
                UserType = user.UserType
            }).ToList();
        }

        public async Task<User> UpdateUserAsync(string email, UserUpdateDto userDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            
            user.Name = userDto.Name;
            user.CompanyName = userDto.CompanyName;
            user.UserType = userDto.UserType;

            await _userRepository.UpdateAsync(user);
            return user;
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