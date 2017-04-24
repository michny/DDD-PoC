using System.Security.Principal;
using System.Web;
using DDD.CommercePoC.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DDD.CommercePoC.Web.Infrastructure.Extensions
{
    public static class PrincipalExtensions
    {
        //TODO Make testable! Using it as an extension method makes it very untestable as there is no OwinContext during Unit tests
        public static ApplicationUser GetApplicationUser(this IPrincipal principal, HttpContextBase httpContext)
        {
            var userId = principal?.Identity?.GetUserId();
            var user = httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            return user;
        }
    }
}