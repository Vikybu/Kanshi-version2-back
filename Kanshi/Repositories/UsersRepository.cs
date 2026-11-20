using Kanshi.Data;
using Kanshi.Models;
using Microsoft.EntityFrameworkCore;

namespace Kanshi.Repositories
{
    public class UsersRepository
    {
        private readonly KanshiDbContext _context;

        public UsersRepository(KanshiDbContext context)
        {
            _context = context;
        }

        // Recherche un utilisateur par son numéro de matricule
        public async Task<Users?> GetByRegistrationNumberAsync(
            string registrationNumber)
        {
            return await _context.Users
                .FirstOrDefaultAsync(
                    u => u.RegistrationNumber == registrationNumber
                );
        }
    }
}
