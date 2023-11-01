using Microsoft.AspNetCore.Mvc;
using RealShop.Services.DTOs.Orders;
using RealShop.Services.Interfaces.Orders;

namespace RealShop.Api.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _service;

        public OrdersController(IOrdersService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] OrdersForCreationDto dto) =>
            Ok(await _service.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> SelectAllAsync() =>
            Ok(await _service.RetriveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> SelectByIdAsync([FromRoute(Name ="id")] long id)=>
            Ok(await _service.RetriveByIdAsync(id));

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name ="id")] long id,OrdersForUpdateDto dto)=>
            Ok(await _service.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name ="id")] long id)=>
            Ok(await _service.DeleteAsync(id));
       
    }
}
