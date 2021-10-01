using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Torneio.API.Exceptions;
using Torneio.API.Interfaces.Services;
using Torneio.API.Models.Dtos;

namespace Torneio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest login)
        {
            try
            {
                var response = await _authService.Login(login);
                return Ok(response);
            }
            catch (UsuarioInvalidoException ex)
            {
                return Unauthorized(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
