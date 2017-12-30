using DotNetCore2.App.Middleware;
using DotNetCore2.EF;
using DotNetCore2.EF.Commands;
using DotNetCore2.EF.Commands.Contracts;
using DotNetCore2.EF.Queries;
using DotNetCore2.EF.Queries.Contracts;
using DotNetCore2.Model.Domain;
using DotNetCore2.Services;
using DotNetCore2.WebApi.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddDbContext<CoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CoreConnection")));

            services.AddScoped(typeof(ICoreEntityInsertCommand<>), typeof(CoreEntityInsertCommand<>));
            services.AddScoped(typeof(ICoreGetByIdQuery<>), typeof(CoreGetByIdQuery<>));
            services.AddScoped(typeof(ICoreGetAllQuery<>), typeof(CoreGetAllQuery<>));
            services.AddScoped<CurrentApplicationUserService>(); //might be wrong?? might have to be singleton?

            services.AddMvc();

            //Configure scoped services does not work!! yet 
            //services.ConfigureCommandServices();

            //configure the jwt   
            services.ConfigureJwtAuthService(Configuration);

            services.Configure<Audience>(Configuration.GetSection("Audience"));
            services.Configure<AppEnvironment>(Configuration.GetSection("AppEnvironment"));
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
