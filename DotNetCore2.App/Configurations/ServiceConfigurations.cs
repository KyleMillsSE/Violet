using DotNetCore2.EF.Commands;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace DotNetCore2.WebApi.Configurations
{
    public static class ServiceConfigurations
    {
        private const string COMMAND_NAMESPACE = "DotNetCore2.EF.Commands";

        public static void ConfigureCommandServices(this IServiceCollection services)
        {
            //var commandServices = typeof(CommandBootstrap)
            //    .Assembly
            //    .ExportedTypes
            //    .Where(ep => ep.GetInterfaces().Any() && ep.Namespace.Contains(COMMAND_NAMESPACE))
            //    .Select(ep => new { Interface = ep.GetInterfaces().First(), Type = ep });

            //foreach (var service in commandServices.Where(cs => !cs.Interface.ContainsGenericParameters))
            //    services.AddScoped(service.Interface, service.Type);
        }

        public static void ConfigureJwtAuthService(this IServiceCollection services, IConfiguration Configuration)
        {
            var audienceConfig = Configuration.GetSection("Audience");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!  
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim  
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Iss"],

                // Validate the JWT Audience (aud) claim  
                ValidateAudience = true,
                ValidAudience = audienceConfig["Aud"],

                // Validate the token expiry  
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenValidationParameters;
            });
        }
    }
}
