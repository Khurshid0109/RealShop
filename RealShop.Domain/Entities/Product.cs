﻿using RealShop.Domain.Commons;
using RealShop.Domain.Enums;

namespace RealShop.Domain.Entities
{
    public class Product:Auditable
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }  
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        //Relationship with Category

        public CategoryEnum Categories { get; set; }
    }
}
