using System;
using System.Collections.Generic;

namespace DDD.CommercePoC.Web.Models
{
    public class ViewOrderViewModel : BaseViewModel
    {
        public Guid Id { get; set; }

        public IEnumerable<ViewOrderItemViewModel> OrderItems { get; set; }
        
        public Guid CustomerId { get; set; }
        
        public string CustomerName { get; set; }
    }
}