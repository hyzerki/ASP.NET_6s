using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace lab8.Models
{
    public class AppContext:DbContext
    {
        public DbSet<PhoneEntry> phones { get; set; } = null!;

        public AppContext(DbContextOptions<AppContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
