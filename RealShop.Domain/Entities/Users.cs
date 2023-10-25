using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class Users:Auditable
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string PhoneNumber { get; set; } 

        //Relationship with Order
        public IEnumerable<Orders> Orders { get; set; }
    }
}
