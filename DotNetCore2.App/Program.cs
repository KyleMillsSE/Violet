using DotNetCore2.EF;
using DotNetCore2.EF.Seeds.Dev;
using DotNetCore2.Model.Domain.Utils;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace DotNetCore2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<CoreContext>();
                    var appEnvironment = services.GetRequiredService<IOptions<AppEnvironment>>();

                    context.Database.Migrate();

                    switch (appEnvironment.Value.Seeding)
                    {
                        case "Dev":
                            CoreDevSeeder.Seed(context);
                            break;
                        default:
                            CoreDevSeeder.Seed(context);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                   // var logger = services.GetRequiredService<ILogger<Program>>();
                    //logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
    }
}
