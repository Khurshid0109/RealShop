using System.ComponentModel.DataAnnotations;

namespace RealShop.Services.DTOs.Users;
public class UserForUpdateDto
{
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}