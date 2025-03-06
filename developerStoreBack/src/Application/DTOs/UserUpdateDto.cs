using DeveloperStoreBack.Domain.Enums;

namespace DeveloperStoreBack.Application.DTOs{
public class UserUpdateDto
{
    public string Name { get; set; }
    public string CompanyName { get; set; }
    public UserType UserType { get; set; }
}
}