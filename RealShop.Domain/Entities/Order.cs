using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class Order:Auditable
    {
        //Relationship with User
        public long UserId { get; set; }
        public User User { get; set; }
                                            
        //Relationship with OrderItems
        public ICollection<Product> Products { get; set; }
    }
}
