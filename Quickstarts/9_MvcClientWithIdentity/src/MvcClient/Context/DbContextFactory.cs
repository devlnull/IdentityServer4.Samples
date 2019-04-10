using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MvcClient.Context
{
    public static class DbContextFactory
    {
        public static IConfigurationRoot GetConfigurationRoot()
        {
            var builder = GetConfigurationBuilder();
            return builder.Build();
        }

        public static IConfigurationBuilder GetConfigurationBuilder()
        {
            var hostingBuilder = new WebHostBuilder();
            var environment = hostingBuilder.GetSetting("environment");
            var config = new ConfigurationBuilder();
            config.SetBasePath($"{Directory.GetCurrentDirectory()}");
            config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables();
            return config;
        }

        public static DbContextOptionsBuilder<AppDbContext> CreateAppDbContextOptionBuilder()
        {
            var configuration = GetConfigurationRoot();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            return builder;
        }
    }
}