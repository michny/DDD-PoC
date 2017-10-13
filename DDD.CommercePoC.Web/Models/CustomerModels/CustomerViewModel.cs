using System;

namespace DDD.CommercePoC.Web.Models.CustomerModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}