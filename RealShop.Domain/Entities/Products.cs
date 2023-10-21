using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class Products:Auditable
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }  

        //Relationship with Category
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }


        //Relationship with OrderItems
        public ICollection<OrderItems> OrderItems { get; set; }
    }
}
