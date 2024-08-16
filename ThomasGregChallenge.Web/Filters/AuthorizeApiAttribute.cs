using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ThomasGregChallenge.Web
{
    public class AuthorizeApiAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cookie = context.HttpContext.Request.Cookies["AuthToken"];
            if (string.IsNullOrEmpty(cookie))
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}