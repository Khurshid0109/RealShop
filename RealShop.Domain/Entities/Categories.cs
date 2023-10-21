using RealShop.Domain.Commons;
using RealShop.Domain.Enums;

namespace RealShop.Domain.Entities
{
    public class Categories:Auditable
    {
        public CategoryEnum Category { get; set; } 

        //Relationship with Product
        public ICollection<Products> Products { get; set; }
    }
}
