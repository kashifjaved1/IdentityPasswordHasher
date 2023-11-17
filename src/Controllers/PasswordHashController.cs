using IdentityPasswordHasher.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IdentityPasswordHasher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordHashController : ControllerBase
    {
        private readonly IPasswordHashService _service;

        public PasswordHashController(IPasswordHashService service)
        {
            _service = service;
        }

        [HttpGet("GenerateHash")]
        public async Task<IActionResult> GetPasswordHash(string password)
        {
            var result = await _service.GenerateHash(password);

            return result.Succeeded == true ? Ok(result.Data) : BadRequest(result.Error);
        }
    }
}
