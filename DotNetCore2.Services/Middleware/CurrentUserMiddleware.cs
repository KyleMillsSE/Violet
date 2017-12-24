using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace DotNetCore2.Services.Middlware
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
        public async Task Invoke(HttpContext context, ApplicationUserContext applicationUserContext)
        {
            var userId = context.User.FindFirst("UniqueUserIndentifier")?.Value;

            if (!String.IsNullOrWhiteSpace(userId))
                applicationUserContext.SetCurrentUser(userId);

            await next(context);
        }
    }
}
