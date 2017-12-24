using DotNetCore2.Services.Middlware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCore2.Services.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDiscoverCurrentUserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DiscoverCurrentUserMiddleware>();
        }
    }
}
