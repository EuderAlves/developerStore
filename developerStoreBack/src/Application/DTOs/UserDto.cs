using DeveloperStoreBack.Domain.Entities;
using DeveloperStoreBack.Domain.Enums;

namespace DeveloperStoreBack.Application.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public UserType UserType { get; set; }

       
        public static UserDto FromUser(User user)
        {
            return new UserDto
            {
                Id = user.Id.ToString(),
                Email = user.Email,
                Name = user.Name,
                CompanyName = user.CompanyName,
                UserType = user.UserType
            };
        }
    }
}