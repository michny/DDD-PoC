using System.Web;
using System.Web.Mvc;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Web.Infrastructure.Alerts;
using DDD.CommercePoC.Web.Infrastructure.Extensions;

namespace DDD.CommercePoC.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICurrentCart _currentCart;
        private readonly ICurrentUser _currentUser;
        private readonly HttpContextBase _httpContext;

        public HomeController(ICurrentCart currentCart, ICurrentUser currentUser, HttpContextBase httpContext)
        {
            _currentCart = currentCart;
            _currentUser = currentUser;
            _httpContext = httpContext;
        }

        public ActionResult Index()
        {
            var user = _currentUser.User.GetApplicationUser(_httpContext);

            return View()
                .WithInfo($"CartId {_currentCart.Cart.Id}. " +
                          $"Cart Items count: {_currentCart.Cart.CartLineItems.Count}. " +
                          $"Username: {user?.UserName}. " +
                          $"CustomerId: {user?.CustomerId}")
                .WithWarning("ARGH!")
                .WithError("DOH!")
                .WithSuccess("HURRAY!");
        }
        
        [Route("shop")]
        public ActionResult NgIndex()
        {
            return View("NgApp");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Hello()
        {
            return View();
        }
    }
}