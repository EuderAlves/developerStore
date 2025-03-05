using DeveloperStoreBack.Domain.Enums;

namespace DeveloperStoreBack.Application.DTOs
{
    public class UserDataDto
    {
        public required IdDto Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string CompanyName { get; set; }
        public UserType UserType { get; set; }
    }

    public class IdDto
    {
        public int Timestamp { get; set; }
        public DateTime CreationTime { get; set; }
    }
}