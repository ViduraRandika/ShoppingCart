using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccessLayer.DataContext
{
    public class DatabaseContextFactory:IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}