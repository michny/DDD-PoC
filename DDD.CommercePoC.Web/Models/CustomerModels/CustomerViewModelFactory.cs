using System;
using System.Security.Principal;
using System.Web;
using DDD.CommercePoC.Shop.Core.Model;
using DDD.CommercePoC.Web.Infrastructure.Extensions;

namespace DDD.CommercePoC.Web.Models.CustomerModels
{
    public class CustomerViewModelFactory : IViewModelFactory<Customer, CustomerViewModel>
    {
        private readonly HttpContextBase _httpContext;

        public CustomerViewModelFactory(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public CustomerViewModel Create(Customer entity)
        {
            throw new NotImplementedException("Use instead Create(Customer, ICurrentUser)");
        }

        public CustomerViewModel Create(Customer entity, IPrincipal userInfo)
        {
            var appUser = userInfo?.GetApplicationUser(_httpContext);
            return new CustomerViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = appUser?.Email, //TODO MNY this should probably also be on the customer object. 
                IsAuthenticated = userInfo?.Identity?.IsAuthenticated ?? false
            };
        }
    }
}