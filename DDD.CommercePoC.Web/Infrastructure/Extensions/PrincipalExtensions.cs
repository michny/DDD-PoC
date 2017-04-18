using System.Security.Principal;
using System.Web;
using DDD.CommercePoC.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DDD.CommercePoC.Web.Infrastructure.Extensions
{
    public static class PrincipalExtensions
    {
        public static ApplicationUser GetApplicationUser(this IPrincipal principal, HttpContextBase httpContext)
        {
            var userId = principal?.Identity?.GetUserId();
            var user = httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            return user;
        }
    }
}