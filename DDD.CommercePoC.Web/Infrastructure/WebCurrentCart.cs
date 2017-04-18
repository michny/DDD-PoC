using System;
using System.Web;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.CartAggregate;

namespace DDD.CommercePoC.Web.Infrastructure
{
    public class WebCurrentCart : ICurrentCart
    {
        private readonly HttpSessionStateWrapper _session;
        private readonly ICartRepository _cartRepository;

        private const string SessionVariableNameCurrentCartId = "CurrentCartId";

        public WebCurrentCart(HttpSessionStateWrapper session, ICartRepository cartRepository)
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
                    _cart = _cartRepository.Single(cart => cart.Id == Id);
                }

                return _cart;
            }
        }

        public Guid Id
        {
            get => new Guid(_session[SessionVariableNameCurrentCartId].ToString());
            set => _session[SessionVariableNameCurrentCartId] = value;
        }
    }
}