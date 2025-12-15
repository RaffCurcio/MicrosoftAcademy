using Microsoft.EntityFrameworkCore;
using ScuolaAPI.Models;

namespace ScuolaAPI.Data
{
    public class ScuolaContext : DbContext
    {
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Corso> Corsi { get; set; }

        // Costruttore per Dependency Injection - la connection string viene da appsettings.json
        public ScuolaContext(DbContextOptions<ScuolaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Matricola univoca per Studente
            modelBuilder.Entity<Studente>()
                .HasIndex(s => s.Matricola)
                .IsUnique();

            // Relazione molti-a-molti Studente <-> Corso
            modelBuilder.Entity<Studente>()
                .HasMany(s => s.Corsi)
                .WithMany(c => c.Studenti);

            // Relazione molti-a-molti Corso <-> Docente
            modelBuilder.Entity<Corso>()
                .HasMany(c => c.Docenti)
                .WithMany(d => d.Corsi);
        }
    }
}
 