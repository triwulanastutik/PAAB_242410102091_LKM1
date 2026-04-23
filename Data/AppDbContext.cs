using Microsoft.EntityFrameworkCore;
using CareBridgeAPI.Models;

namespace CareBridgeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<DisabledPerson> DisabledPersons { get; set; }
        public DbSet<Need> Needs { get; set; }
        public DbSet<Donation> Donations { get; set; }
    }
}