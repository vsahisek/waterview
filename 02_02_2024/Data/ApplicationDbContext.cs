using waterview.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace waterview.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder) // unique name na urovni DB TODO
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Value> Values { get; set; }
    }
}