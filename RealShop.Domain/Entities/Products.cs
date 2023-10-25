using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class Products:Auditable
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }  
        public int Quantity { get; set; }

        //Relationship with Category
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }


        //Relationship with OrderItems
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
