using DotNetCore2.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace DotNetCore2.App.Middleware
{
    public class DiscoverCurrentUserMiddleware
    {
        private readonly RequestDelegate next;

        public DiscoverCurrentUserMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="applicationUserContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, CurrentApplicationUserService currentApplicationUserService)
        {
            var userId = context.User.FindFirst("UniqueUserIndentifier")?.Value;

            if (!String.IsNullOrWhiteSpace(userId))
                currentApplicationUserService.SetCurrentUser(userId);

            await next(context);
        }
    }



}
