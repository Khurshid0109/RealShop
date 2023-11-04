using System.ComponentModel.DataAnnotations;

namespace RealShop.Services.DTOs.Users;
public class UserForUpdateDto
{
    [Required]
    [MinLength(2), MaxLength(25)]
    public string FirstName { get; set; }

    [Required]
    [MinLength(2), MaxLength(25)]
    public string LastName { get; set; }

    [Required]
    [EmailValidation(ErrorMessage = "Please enter a valid email address!")]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string PhoneNumber { get; set; }
}