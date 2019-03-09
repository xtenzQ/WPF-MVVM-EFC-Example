using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ResearchersWPF.Data.Model
{
    public class ResDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Monograph> Monographs { get; set; }
        public DbSet<Presentation> Presentations { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Researcher> Researchers { get; set; }

        public ResDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Researcher>()
                .HasMany<Article>(g => g.Articles)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany<Monograph>(g => g.Monographs)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany<Presentation>(g => g.Presentations)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany<Report>(g => g.Reports)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Researchers.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }
    }
}