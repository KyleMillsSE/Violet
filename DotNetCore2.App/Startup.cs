using DotNetCore2.EF;
using DotNetCore2.EF.Commands;
using DotNetCore2.EF.Commands.Contracts;
using DotNetCore2.Model.Domain;
using DotNetCore2.Services;
using DotNetCore2.Services.Middleware;
using DotNetCore2.WebApi.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCore2
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);


            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CoreContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CoreConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CoreContext>();

            services.AddScoped(typeof(IEntityInsertCommand<>), typeof(EntityInsertCommand<>));
            services.AddSingleton(typeof(ApplicationUserContext), typeof(ApplicationUserContext));

            services.AddMvc();

            //Configure scoped services does not work!!
           // services.ConfigureCommandServices();
            //Configure identity
            services.ConfigureIdentityService();
            //configure the jwt   
            services.ConfigureJwtAuthService(Configuration);

            services.Configure<Audience>(Configuration.GetSection("Audience"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            //enable jwt
            app.UseAuthentication();
            // custom middlware
            app.UseDiscoverCurrentUserMiddleware();
            app.UseMvc();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                // Setup additional routing for SPA
                routes.MapSpaFallbackRoute(
                  name: "spa-fallback",
                  defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
