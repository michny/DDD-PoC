using System.Collections.Generic;
using DDD.CommercePoC.Shop.Core.Model.ValueObjects;

namespace DDD.CommercePoC.Web.Models.ProductModels
{
    public class VariantViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public string PriceFormatted { get; set; }

        public string ImageUrl { get; set; }
    }
}