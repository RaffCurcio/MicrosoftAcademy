using Microsoft.EntityFrameworkCore;
using EfDemo.Models;

public class ScuolaContext : DbContext
{
    public DbSet<Studente> Studenti { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connectionString = "server=localhost;port=3306;database=ScuolaDB;user=root;password=Password123;";

        options.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 34))
        );
    }
}
