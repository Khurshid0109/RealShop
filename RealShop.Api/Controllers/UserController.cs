using Microsoft.AspNetCore.Mvc;
using RealShop.Services.DTOs.Users;
using RealShop.Services.Interfaces;

namespace RealShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() =>
            Ok(await _service.RetriveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")]long id) =>
            Ok(await _service.RetriveByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserForCreationDto dto) =>
            Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name ="id")]long id,[FromBody]UserForUpdateDto dto) =>
            Ok(await _service.ModifyAsync(id,dto));


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name ="id")]long id) =>
            Ok(await _service.DeleteAsync(id));
    }
}
