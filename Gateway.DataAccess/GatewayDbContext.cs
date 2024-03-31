using Gateway.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Gateway.DataAccess;

public class GatewayDbContext : DbContext
{
    private readonly string _dbPath;

    public DbSet<User>? Users { get; set; }

    public GatewayDbContext(DbContextOptions<GatewayDbContext> options)
        : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        _dbPath = Path.Join(path, "locasubs.db");
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_dbPath}");
    }
}