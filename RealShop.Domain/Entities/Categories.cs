using RealShop.Domain.Enums;
using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class Categories:Auditable
    {
        public CategoryEnum Category { get; set; } 

        //Relationship with Product
        public ICollection<Product> Products { get; set; }
    }
}