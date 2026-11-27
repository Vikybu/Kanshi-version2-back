
using Kanshi.DTOs;
using Kanshi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kanshi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        // Injection du service
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginGlobal([FromBody] LoginDTO loginDTO)
        {
            var response = await _authService.LoginAsync(loginDTO.RegistrationNumber, loginDTO.Password);

            if (response == null)
            {
                return Unauthorized(new
                {
                    message = "Numéro de matricule ou mot de passe incorrect."
                });
            }

            return Ok(response);
        }
    }
}
