using System;
using System.Linq;
using System.Web.Http;
using DDD.CommercePoC.SharedKernel.Exceptions;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model.ProductAggregate;
using DDD.CommercePoC.Web.Models.ProductModels;

namespace DDD.CommercePoC.Web.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private readonly ProductViewModelFactory _viewModelFactory;
        private readonly IProductRepository _productRepository;

        public ProductsController(ProductViewModelFactory viewModelFactory, IProductRepository productRepository)
        {
            _viewModelFactory = viewModelFactory;
            _productRepository = productRepository;
        }

        // GET: api/Products
        public IHttpActionResult Get()
        {
            var products = _productRepository.ManyWithVariants();
            var productsList = products.AsEnumerable().Where(p => p.Variants != null && p.Variants.Any()).Select(_viewModelFactory.Create).ToList();
            return Ok(productsList);
        }

        // GET: api/Products/5
        public IHttpActionResult Get(Guid id)
        {
            try
            {
                var product = _productRepository.SingleWithVariants(p => p.Id == id);
                return Ok(_viewModelFactory.Create(product));
            }
            catch (EntityNotFoundException<Product>)
            {
                return NotFound();
            }
        }
    }
}
