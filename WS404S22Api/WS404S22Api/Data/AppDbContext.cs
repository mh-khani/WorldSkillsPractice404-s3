
using Microsoft.EntityFrameworkCore;
using WS404S22Api.Models;

namespace WS404S22Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Ticket> Tickets     { get; set; }
        public DbSet<TicketSection> TicketSections { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=.;Database=WS404S32;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Section>().Property(b => b.PlaceId)
                .ValueGeneratedNever();
        }
    }
}
