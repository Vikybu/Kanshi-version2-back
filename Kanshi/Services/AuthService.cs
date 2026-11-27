using Kanshi.DTOs;
using Kanshi.Models;
using Kanshi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kanshi.Services
{
    public class AuthService
    {
        private readonly UsersRepository _usersRepository;
        private readonly PasswordHasher<Users> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(UsersRepository usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
            _passwordHasher = new PasswordHasher<Users>();
        }

        public async Task<AuthResponse?> LoginAsync(string registrationNumber, string password)
        {
            //Recherche de l'utilisateur
            var user = await _usersRepository.GetByRegistrationNumberAsync(registrationNumber);
            if (user == null)
                return null;

            //Vérifier s'il est bien actif
            if (!user.IsActive)
                return null;

            //Vérification du mot de passe
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            //Création claims de JWT
            var claims = new[]
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.Id.ToString()
                ),

                new Claim(
                    ClaimTypes.Name,
                    user.RegistrationNumber
                ),

                //Permet d'inscrire le role de l'utilisateur dans le token
                new Claim(
                    ClaimTypes.Role,
                    user.Role
                )
            };

            // Récupération de la clé secrète
            var jwtKey = _configuration["Jwt:Key"];

            if (string.IsNullOrWhiteSpace(jwtKey))
            {
                throw new InvalidOperationException(
                    "La clé JWT n'est pas configurée."
                );
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            );

            // Définition de la signature du token - permet de signer le token avec la clé secrète
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            // Définition de l'expiration (8 heures)
            var expiresAt = DateTime.UtcNow.AddHours(8);

            // Génération du JWT
            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiresAt,
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler()
                .WriteToken(token);

            // Retour des informations nécessaires
            return new AuthResponse
            {
                Token = tokenString,
                ExpiresAt = expiresAt,
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                RegistrationNumber = user.RegistrationNumber,
                Role = user.Role
            };
        }
    }
}