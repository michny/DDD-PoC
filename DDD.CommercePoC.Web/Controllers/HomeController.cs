using System.Linq;
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
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentCart _currentCart;
        private readonly ICurrentUser _currentUser;
        private readonly HttpContextWrapper _httpContext;

        public HomeController(ICartRepository cartRepository, IProductRepository productRepository, 
            IUnitOfWork unitOfWork, ICurrentCart currentCart, ICurrentUser currentUser, HttpContextWrapper httpContext)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _currentCart = currentCart;
            _currentUser = currentUser;
            _httpContext = httpContext;
        }

        public ActionResult Index()
        {
            var user = _currentUser.User.GetApplicationUser(_httpContext);

            return View().WithInfo($"CartId {_currentCart.Cart.Id}. Cart Items count: {_currentCart.Cart.CartLineItems.Count}. " +
                                   $"Username: {user.UserName}. CustomerId: {user.CustomerId}");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var carts = _cartRepository.ManyWithCartLineItems().ToList();
            var variants = _productRepository.ManyWithVariants().SelectMany(e => e.Variants);

            using (_unitOfWork.BeginTransaction())
            {
                carts.First().AddVariant(variants.FirstOrDefault());
            }
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Hello()
        {
            //using (_unitOfWork.BeginTransaction())
            //{
            //    var guid = Guid.NewGuid();
            //    _orderRepository.Add(new Order(guid, new Guid("11111111-1111-1111-1111-111111111111")));
            //}
            return View();
        }
    }
}