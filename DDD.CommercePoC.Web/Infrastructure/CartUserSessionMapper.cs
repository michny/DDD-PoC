using System;
using System.Web;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.SharedKernel.Tasks;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Web.Infrastructure.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DDD.CommercePoC.Web.Infrastructure
{
    public class CartUserSessionMapper : IRunOnRequestRightBeforeCustomCode
    {
        private readonly HttpSessionStateBase _session;
        private readonly HttpContextBase _httpContext;
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentCart _currentCart;
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public int Order => 1000;

        public CartUserSessionMapper(HttpSessionStateBase session, HttpContextBase httpContext, ICurrentUser currentUser, 
            ICurrentCart currentCart, ICartRepository cartRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _session = session;
            _httpContext = httpContext;
            _currentUser = currentUser;
            _currentCart = currentCart;
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public void Execute()
        {
            if (_session is EmptyHttpSessionState)
                return;

            if (_currentUser.User.Identity.IsAuthenticated)
            {
                EnsureSettingsForLoggedInUser();
            }
            else
            {
                EnsureSettingsForAnonymousUser();
            }
        }

        private void EnsureSettingsForLoggedInUser()
        {
            var applicationUser = _currentUser.User.GetApplicationUser(_httpContext);
            if (!applicationUser.CustomerId.HasValue)
            {
                //NO customer created for the user yet.
                var customer = CreateNewCustomer(applicationUser.UserName);
                applicationUser.CustomerId = customer.Id;
                var userManager = _httpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                userManager.Update(applicationUser);
            }
            else
            {
                _currentUser.CustomerId = applicationUser.CustomerId.Value;
                var currentCart = _cartRepository.Single(cart => cart.CustomerId == applicationUser.CustomerId.Value);
                _currentCart.Id = currentCart.Id;
            }
        }

        private void EnsureSettingsForAnonymousUser()
        {
            //Ensures that a customer and a cart exists for the session.
            if (_currentCart.Id == null)
            {
                CreateNewCustomer("Dummy customer");
            }
        }

        private Customer CreateNewCustomer(string name)
        {
            using (_unitOfWork.BeginTransaction())
            {
                var customer = new Customer(Guid.NewGuid(), name);
                _customerRepository.Add(customer);
                _currentUser.CustomerId = customer.Id;
                var cart = _cartRepository.Add(new Cart(Guid.NewGuid(), customer.Id));
                _currentCart.Id = cart.Id;

                return customer;
            }
        }
    }
}