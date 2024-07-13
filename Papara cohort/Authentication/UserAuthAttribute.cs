using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class UserAuthAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var authService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();

        string username = context.HttpContext.User.Identity.Name;
        string password = context.HttpContext.Request.Headers["Password"];

        if (!authService.Authenticate(username, password))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}
