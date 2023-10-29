using RealShop.Domain.Enums;
using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class User:Auditable
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string PhoneNumber { get; set; }
        public UserRoleEnum UserRole { get; set; }
        public bool Active { get; set; }

        //Relationship with Order
        public IEnumerable<Order> Orders { get; set; }
    }
}
