using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class Order:Auditable
    {
        //Relationship with User
        public int UserId { get; set; }
        public User Users { get; set; }

        //Relationship with OrderItems
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
