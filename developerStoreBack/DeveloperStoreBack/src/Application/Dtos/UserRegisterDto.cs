namespace DeveloperStoreBack.Application.DTOs
{
    public class UserRegisterDto
    {
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string Name { get; set; }
        public required string CompanyName { get; set; }
    }
}