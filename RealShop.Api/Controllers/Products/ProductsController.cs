using Microsoft.AspNetCore.Mvc;
using RealShop.Services.DTOs.Products;
using RealShop.Services.Interfaces.Products;

namespace RealShop.Api.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

       
        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromForm] ProductForCreationDto dto) =>
            Ok(await _service.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> SelectAllAsync() =>
            Ok(await _service.RetriveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> SelectByIdAsync([FromRoute] long id) =>
            Ok(await _service.RetriveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] long id, [FromForm] ProductForUpdateDto dto)=>
            Ok(await _service.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) =>
            Ok(await _service.DeleteAsync(id));

    }
}
