
using Microsoft.AspNetCore.Mvc;
using RealShop.Api.Models;
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
            Ok(new Responce
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.RetriveAllAsync()
            });

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long? id) =>
            Ok(new Responce
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.RetriveByIdAsync(id)
            });

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserForCreationDto dto) =>
            Ok(new Responce
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.CreateAsync(dto)
            });

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UserForUpdateDto dto) =>
            Ok(new Responce
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.UpdateAsync(dto)
            });


        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long? id) =>
            Ok(new Responce
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _service.DeleteAsync(id)
            });
    }
}
