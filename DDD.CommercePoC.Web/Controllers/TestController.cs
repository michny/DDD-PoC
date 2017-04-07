using System.Web.Mvc;

namespace DDD.CommercePoC.Web.Controllers
{
    public class TestController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Post()
        {
            //var hubContext = GlobalHost.ConnectionManager.GetHubContext<TestHub>();
            //hubContext.Clients.User(User.Identity.Name).hello("LOLS");
            return View("Index");
        }
    }
}