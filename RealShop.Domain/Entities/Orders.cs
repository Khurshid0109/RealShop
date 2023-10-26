using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class Orders:Auditable
    {
        //Relationship with User
        public int UserId { get; set; }
        public Users Users { get; set; }

        //Relationship with OrderItems
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
