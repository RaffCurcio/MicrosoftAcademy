using System;
using Microsoft.EntityFrameworkCore;
using ScuolaNoRepo.Model;

namespace ScuolaNoRepo.Data
{
    public class ScuolaContext : DbContext
    {
        public DbSet <Studente> Studenti { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Corso> Corsi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = "server=localhost;port=3306;database=scuola_db;user=root;password=Password123;";

            options.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 34))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Studente>()
                .HasIndex(s => s.matricola)
                .IsUnique();
            modelBuilder.Entity<Studente>()
                .HasMany(s => s.Corsi)
                .WithMany(c => c.Studenti);
            modelBuilder.Entity<Corso>()
                .HasMany(c => c.Docenti)
                .WithMany(d => d.Corsi);
        }
    }
}