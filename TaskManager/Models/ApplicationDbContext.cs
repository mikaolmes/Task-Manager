using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explizite Tabellennamen definieren
            modelBuilder.Entity<TodoTask>().ToTable("Tasks");
            modelBuilder.Entity<Note>().ToTable("Notes");

            // Weitere Konfigurationen
            modelBuilder.Entity<TodoTask>().Property(t => t.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Note>().Property(n => n.Title).IsRequired().HasMaxLength(100);

            // Seed-Daten hinzufügen
            modelBuilder.Seed();
        }
    }
}