using System;
using System.Security.Principal;
using System.Web;
using DDD.CommercePoC.SharedKernel.Interfaces;

namespace DDD.CommercePoC.Web.Infrastructure
{
    public class WebCurrentUser : ICurrentUser
    {
        private readonly HttpContextWrapper _context;

        public WebCurrentUser(HttpContextWrapper context)
        {
            _context = context;
        }

        public IPrincipal User => _context.User;
        public Guid CustomerId { get; set; }
    }
}