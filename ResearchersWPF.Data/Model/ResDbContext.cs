using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

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
            Batteries.Init();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Researcher>()
                .HasMany(g => g.Articles)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany(g => g.Monographs)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany(g => g.Presentations)
                .WithOne(s => s.Researcher)
                .HasForeignKey(e => e.ResearcherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Researcher>()
                .HasMany(g => g.Reports)
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