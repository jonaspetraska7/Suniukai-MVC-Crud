using Microsoft.EntityFrameworkCore;
using Suniukai_MVC_Paskaita.Models;

namespace Suniukai_MVC_Paskaita.Data
{
    public class SuniukaiDbContext : DbContext
    {
        public SuniukaiDbContext(DbContextOptions<SuniukaiDbContext> options) : base(options) { }

        public DbSet<Suniukas> Suniukai { get; set; }

        public DbSet<Kaciukas> Kaciukai { get; set; }
    }
}
