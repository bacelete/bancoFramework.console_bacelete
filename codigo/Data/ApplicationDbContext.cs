namespace codigo.Data;
using Microsoft.EntityFrameworkCore;

using codigo.Model; 

public class ApplicationDbContext : DbContext
{
    public DbSet<Pessoa> Pessoa { get; set; }
    public DbSet<Cliente> Cliente { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=localhost;user=root;password=root;database=framework";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 44));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

}