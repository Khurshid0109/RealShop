using RealShop.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace RealShop.Services.DTOs.Products;
public class ProductForCreationDto
{
    [Required]
    [MinLength(2), MaxLength(25)]
    public string Name { get; set; }

    [Required]
    [MinLength(5), MaxLength(300)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }
    public CategoryEnum Categories { get; set; }
    public int Quantity { get; set; }
    public string Color { get; set; }

    [Required]
    public IFormFile ImageUrl { get; set; }
}
