
using System.ComponentModel.DataAnnotations;

namespace RealShop.Services.DTOs.Users
{
    public class UserForCreationDto
    {
        [Required]
        [MinLength(2),MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}