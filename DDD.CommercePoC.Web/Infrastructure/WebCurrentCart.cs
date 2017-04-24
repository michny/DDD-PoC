using System;
using System.Web;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;

namespace DDD.CommercePoC.Web.Infrastructure
{
    public class WebCurrentCart : ICurrentCart
    {
        private readonly HttpSessionStateBase _session;
        private readonly ICartRepository _cartRepository;

        private const string SessionVariableNameCurrentCartId = "CurrentCartId";

        public WebCurrentCart(HttpSessionStateBase session, ICartRepository cartRepository)
        {
            _session = session;
            _cartRepository = cartRepository;
        }

        private Cart _cart;
        public Cart Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = _cartRepository.Single(cart => cart.Id == Id, includes: cart => cart.CartLineItems);
                }

                return _cart;
            }
        }

        public Guid? Id
        {
            get => _session[SessionVariableNameCurrentCartId] != null ? (Guid?)new Guid(_session[SessionVariableNameCurrentCartId].ToString()) : null;
            set => _session[SessionVariableNameCurrentCartId] = value;
        }
    }
}