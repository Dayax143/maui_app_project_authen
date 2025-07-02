using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maui_app_project.Services;
using Microsoft.EntityFrameworkCore;

namespace maui_app_project.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db;

        public AuthService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is null) return false;

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }

        public async Task RegisterAsync(string username, string password)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new AppUser { Username = username, PasswordHash = hashed };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }
    }
}
