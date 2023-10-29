using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class OrderItem : Auditable
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        //Relationship with Order
        public int OrderId { get; set; }
        public Order Order { get; set; }

        //Relationship with Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}