using Microsoft.AspNetCore.Builder;

namespace DotNetCore2.App.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDiscoverCurrentUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DiscoverCurrentUserMiddleware>();
        }
    }
}
