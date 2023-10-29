using RealShop.Domain.Enums;
using RealShop.Domain.Commons;

namespace RealShop.Domain.Entities
{
    public class Category:Auditable
    {
        public CategoryEnum Categories { get; set; }
        public string Image { get; set; }

        //Relationship with Product
        public ICollection<Product> Products { get; set; }
    }
}