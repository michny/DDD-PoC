using System;

namespace DDD.CommercePoC.Web.Models
{
    public class ViewOrderItemViewModel : BaseViewModel
    {
        public Guid Id { get; set; }

        public string VariantId { get; set; }

        public string VariantName { get; set; }

        public int Count { get; set; }
    }
}