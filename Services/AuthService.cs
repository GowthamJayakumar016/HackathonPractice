using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using NangaNaluPeru.Data;
using NangaNaluPeru.DTOs;
using NangaNaluPeru.Models;
using NangaNaluPeru.Services.Interfaces;

namespace NangaNaluPeru.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (existingUser != null)
                return false;

            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password),
                Role = "User"
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                return null;

            var hashedPassword = HashPassword(dto.Password);

            if (user.PasswordHash != hashedPassword)
                return null;

            return new LoginResponseDto
            {
                Token = GenerateToken(),
                Role = user.Role,
                UserId = user.Id
            };
        }

        // 🔐 Password Hashing
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        // 🔑 Temporary Token (replace with JWT later)
        private string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}