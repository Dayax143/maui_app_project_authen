using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maui_app_project.Services;
using Microsoft.EntityFrameworkCore;

namespace maui_app_project.Services
{
    public class AppDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("C:\\Users\\pc\\Desktop\\litesql.db");
    }
}
