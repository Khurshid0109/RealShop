using Microsoft.AspNetCore.Mvc;
using RealShop.Services.DTOs.Users;
using RealShop.Services.Interfaces.Users;

namespace RealShop.Api.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public UsersAuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> PostAsync(LoginDto dto)=>
            Ok(await _service.AuthenticateAsync(dto));
    }
}
