﻿using System;
using System.Collections.Generic;

namespace DDD.CommercePoC.Web.Models.CartModels
{ 
    public class CartViewModel
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public IEnumerable<CartLineItemViewModel> CartLineItems { get; set; }

        public string PriceFormatted { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }
    }
}