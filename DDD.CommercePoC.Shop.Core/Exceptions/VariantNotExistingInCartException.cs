using System;

namespace DDD.CommercePoC.Shop.Core.Exceptions
{
    public class VariantNotExistingInCartException : Exception
    {
        public Guid CartId { get; }
        public string VariantId { get; }

        public VariantNotExistingInCartException(Guid cartId, string variantId)
        {
            CartId = cartId;
            VariantId = variantId;
        }
    }
}