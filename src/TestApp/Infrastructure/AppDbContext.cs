using AD.BaseTypes.EFCore;
using Microsoft.EntityFrameworkCore;
using TestApp.UserAggregate;

namespace TestApp.Data.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public string DbPath { get; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "testApp.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.AddBaseTypeConversionConvention();
    }
}
