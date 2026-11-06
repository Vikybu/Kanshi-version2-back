using Kanshi.Data;
using Kanshi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kanshi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly KanshiDbContext _context;
        public UsersController(KanshiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers([FromBody] UserRequest request)
        {
            var users = new Users
            {   
                Lastname = request.Lastname,
                Firstname = request.Firstname,
                RegistrationNumber = request.RegistrationNumber,
                Password = request.Password,
                IsActive = true,
                Role = "operator",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow

            };

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }
    }
}

//Ceci est un commentaire de test pour la CI et un 2ème test
