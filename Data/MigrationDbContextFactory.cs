using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure;

public class MigrationDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    //public ApplicationContext CreateDbContext(string[] args)
    //{
    //    var options = new DbContextOptionsBuilder<ApplicationContext>()
    //        .UseNpgsql("Host=localhost;Port=5432;Database=SrudentPickerDB;Username=postgres;Password=1234")
    //        .Options;

    //    return new ApplicationContext(options);
    //}

    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseSqlite("Data Source=design-time.db");
        return new ApplicationContext(optionsBuilder.Options);
    }
}