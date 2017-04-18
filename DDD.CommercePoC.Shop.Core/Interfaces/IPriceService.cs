using DDD.CommercePoC.Shop.Core.Model.CartAggregate;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;

namespace DDD.CommercePoC.Shop.Core.Interfaces
{
    public interface IPriceService
    {
        Money GetTotalCartPrice(Cart cart);

        Money GetCartLineItemPrice(CartLineItem cartLineItem);
    }
}