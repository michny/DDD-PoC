using System;

namespace DDD.CommercePoC.Web.Models.CartModels
{
    public class CartLineItemViewModel
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public string VariantId { get; set; }

        public string VariantName { get; set; }

        public string PriceFormatted { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }
    }
}