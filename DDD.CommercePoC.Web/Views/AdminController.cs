using System.Web.Mvc;
using DDD.CommercePoC.SharedKernel;

namespace DDD.CommercePoC.Web.Views
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}