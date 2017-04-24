using System.Linq;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using JetBrains.Annotations;

namespace DDD.CommercePoC.Web.Models.CartModels
{
    public class CartViewModelFactory
    {
        private readonly IReadOnlyRepository<Variant> _variantRepository;

        public CartViewModelFactory(IReadOnlyRepository<Variant> variantRepository)
        {
            _variantRepository = variantRepository;
        }

        public CartViewModel Create([NotNull] Cart cart)
        {
            return new CartViewModel
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                CartLineItems = cart.CartLineItems.Select(Create).ToList()
            };
        }

        public CartLineItemViewModel Create([NotNull] CartLineItem cartLineItem)
        {
            var variant = _variantRepository.Single(v => v.Id == cartLineItem.VariantId);

            return new CartLineItemViewModel
            {
                Id = cartLineItem.Id,
                Count = cartLineItem.Count,
                VariantId = cartLineItem.VariantId,
                VariantName = variant.Name
            };
        }
    }
}