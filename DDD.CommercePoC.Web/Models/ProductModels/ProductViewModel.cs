using System;
using System.Collections;
using System.Collections.Generic;

namespace DDD.CommercePoC.Web.Models.ProductModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<VariantViewModel> Variants { get; set; }

    }
}