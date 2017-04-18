using System;
using System.Security.Principal;

namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface ICurrentUser
    {
        IPrincipal User { get; }

        Guid CustomerId { get; set; }
    }
}