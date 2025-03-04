namespace DeveloperStoreBack.Application.DTOs
{
    public class UserLoginDto
    {
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}