using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OlympiadWpfApp.DataAccess.Contexts;

namespace OlympiadWpfApp.Migrations.Factories;

public class OlympDbContextFactory : IDesignTimeDbContextFactory<OlympDbContext>
{
    public OlympDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OlympDbContext>();
        optionsBuilder.UseNpgsql(builder =>
        {
            builder.MigrationsAssembly(typeof(OlympDbContextFactory).Assembly.FullName);
        });
        return new OlympDbContext(optionsBuilder.Options);
    }
}