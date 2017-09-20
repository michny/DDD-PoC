using System.Linq;
using DDD.CommercePoC.SharedKernel.Extensions;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using JetBrains.Annotations;

namespace DDD.CommercePoC.Web.Models.ProductModels
{
    /// <inheritdoc />
    public class ProductViewModelFactory : IViewModelFactory<Product, ProductViewModel>
    {
        public ProductViewModel Create(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Variants = product.Variants.Select(Create)
            };
        }

        [NotNull]
        private VariantViewModel Create([NotNull] Variant variant)
        {
            return new VariantViewModel
            {
                Id = variant.Id,
                Name = variant.Name,
                PriceFormatted = variant.Price.ToString(),
                Price = variant.Price.Amount,
                Currency = variant.Price.Currency.DisplayName(),
                ImageUrl = variant.ImageUrl
            };
        }
    }
}