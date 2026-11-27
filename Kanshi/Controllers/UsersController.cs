using Kanshi.Data;
using Kanshi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> CreateUsers([FromBody] UserRequest request)
        {
            var users = new Users
            {
                Lastname = request.Lastname,
                Firstname = request.Firstname,
                RegistrationNumber = request.RegistrationNumber,
                IsActive = true,
                Role = "operator",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var passwordHasher = new PasswordHasher<Users>();

            users.PasswordHash = passwordHasher.HashPassword(
                users,
                request.Password
            );

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                users.Id,
                users.Lastname,
                users.Firstname,
                users.RegistrationNumber,
                users.Role,
                users.IsActive
            });
        }
    }
}
