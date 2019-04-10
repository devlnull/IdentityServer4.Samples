using Microsoft.EntityFrameworkCore.Design;

namespace MvcClient.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var options = DbContextFactory.CreateAppDbContextOptionBuilder().Options;
            return new AppDbContext(options);
        }
    }
}