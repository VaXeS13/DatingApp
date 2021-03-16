using System;
using System.Threading.Tasks;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultConetx = await next();

            if (!resultConetx.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = resultConetx.HttpContext.User.GetUserId();
            var repo = resultConetx.HttpContext.RequestServices.GetService<IUserRepository>();
            var user = await repo.GetUserByIdAsync(userId);
            user.LastActive = DateTime.Now;

            await repo.SaveAllAsync();
        }
    }
}