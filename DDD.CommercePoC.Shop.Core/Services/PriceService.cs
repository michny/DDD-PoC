using System.Linq;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;

namespace DDD.CommercePoC.Shop.Core.Services
{
    public class PriceService : IPriceService
    {
        private readonly IProductRepository _productRepository;

        public PriceService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Money GetTotalCartPrice(Cart cart)
        {
            var total = new Money(Currency.Dkk, 0);
            return cart.CartLineItems.Aggregate(total, (current, cartLineItem) => current + GetCartLineItemPrice(cartLineItem));
        }

        public Money GetCartLineItemPrice(CartLineItem cartLineItem)
        {
            //In a real scenario this would retrieve the data from an external system most likely, in order to calculate possible "mængderabat"
            var product = _productRepository.Single(p => p.Variants.Any(e => e.Id == cartLineItem.VariantId), includes: e => e.Variants);
            var variant = product.Variants.Single(v => v.Id == cartLineItem.VariantId);

            var singleItemPrice = variant.Price;

            return singleItemPrice * cartLineItem.Count;
        }
    }
}