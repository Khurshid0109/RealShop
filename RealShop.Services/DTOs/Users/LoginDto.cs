using System.ComponentModel.DataAnnotations;

namespace RealShop.Services.DTOs.Users;
public class LoginDto
{
    [Required]
    [EmailValidation(ErrorMessage = "Please enter a valid email address!")]
    public string Email { get; set; }
    public string Password { get; set; }
}
