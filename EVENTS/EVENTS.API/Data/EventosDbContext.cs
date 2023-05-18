using EVENTS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EVENTS.API.Data
{
    public class EventosDbContext : DbContext
    {
        public EventosDbContext(DbContextOptions<EventosDbContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .HasKey(e => e.Id);
        }
    }
}