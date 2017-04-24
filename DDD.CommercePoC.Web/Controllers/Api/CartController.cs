using System.Linq;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using DDD.CommercePoC.Web.Models.CartModels;

namespace DDD.CommercePoC.Web.Controllers.Api
{
    //[System.Web.Mvc.RoutePrefix("/api/cart")]
    public class CartController : BaseApiController
    {
        private readonly ICurrentCart _currentCart;
        private readonly IReadOnlyRepository<Variant> _variantRepository;
        private readonly CartViewModelFactory _cartViewModelFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CartController(ICurrentCart currentCart, IReadOnlyRepository<Variant> variantRepository, CartViewModelFactory cartViewModelFactory, 
            IUnitOfWork unitOfWork)
        {
            _currentCart = currentCart;
            _variantRepository = variantRepository;
            _cartViewModelFactory = cartViewModelFactory;
            _unitOfWork = unitOfWork;
        }
        
        /// <summary>
        /// Adds a variant to the cart.
        /// </summary>
        /// <param name="id">The Id of the variant.</param>
        /// <returns></returns>
        public CartLineItemViewModel Post(string id)
        {
            using (_unitOfWork.BeginTransaction())
            {
                var variant = _variantRepository.Single(v => v.Id == id);
                _currentCart.Cart.AddVariant(variant);

                var updatedCartLineItem = _currentCart.Cart.CartLineItems.Single(line => line.VariantId == id);
                return _cartViewModelFactory.Create(updatedCartLineItem);
            }
        }

        /// <summary>
        /// Gets the entire cart.
        /// </summary>
        /// <returns></returns>
        public CartViewModel Get()
        {
            return _cartViewModelFactory.Create(_currentCart.Cart);
        }

        /// <summary>
        /// Deletes a variant from a cart.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CartLineItemViewModel Delete(string id)
        {
            using (_unitOfWork.BeginTransaction())
            {
                _currentCart.Cart.RemoveVariant(id);
                
                var updatedCartLineItem = _currentCart.Cart.CartLineItems.SingleOrDefault(line => line.VariantId == id);
                if (updatedCartLineItem == null)
                    return null;

                return _cartViewModelFactory.Create(updatedCartLineItem);
            }
        }

        public void Delete()
        {
            using (_unitOfWork.BeginTransaction())
            {
                _currentCart.Cart.Clear();
            }
        }
    }
}