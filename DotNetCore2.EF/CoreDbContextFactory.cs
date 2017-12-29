using DotNetCore2.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DotNetCore2.EF
{
    public class CoreDbContextFactory : IDesignTimeDbContextFactory<CoreContext>
    {
        public CoreContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder() //TODO INJECT SCOPE HERE AND GET CONN STRING
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CoreContext>();
            var connectionString = configuration.GetConnectionString("CoreConnection");
            builder.UseSqlServer(connectionString);
            return new CoreContext(builder.Options, new CurrentApplicationUserService());
        }
    }
}
