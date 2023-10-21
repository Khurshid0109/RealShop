using RealShop.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
