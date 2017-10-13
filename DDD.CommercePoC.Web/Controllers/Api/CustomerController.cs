using System;
using System.Web.Http;
using DDD.CommercePoC.SharedKernel;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Model;
using DDD.CommercePoC.Web.Models.CustomerModels;

namespace DDD.CommercePoC.Web.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<Customer> _customerRepository;
        private readonly CustomerViewModelFactory _viewModelFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(ICurrentUser currentUser, IRepository<Customer> customerRepository, CustomerViewModelFactory viewModelFactory, IUnitOfWork unitOfWork)
        {
            _currentUser = currentUser;
            _customerRepository = customerRepository;
            _viewModelFactory = viewModelFactory;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Customer
        /// <summary>
        /// Gets the current customer.
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult Get()
        {
            var customer = _customerRepository.Single(c => c.Id == _currentUser.CustomerId);
            return Ok(_viewModelFactory.Create(customer, _currentUser.User));
        }

        // GET: api/Customer/5
        /// <summary>
        /// Retrieves a specific user by ID. Only allowed by Admins. Normal users should use the Get() to get current customer (themselves).
        /// </summary>
        /// <param name="id">The customerId of the user to get.</param>
        /// <returns></returns>
        [Authorize(Roles = UserRoles.Admin)]
        public IHttpActionResult Get(Guid id)
        {
            var customer = _customerRepository.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(_viewModelFactory.Create(customer, null));
        }

        // POST: api/Customer
        /// <summary>
        /// Add a new user. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Authorize(Roles = UserRoles.Admin)]
        public IHttpActionResult Post([FromBody]CustomerViewModel value)
        {
            //TODO MNY Implement. Should be created using some sort of CustomerService. I am not quite sure if it belongs in the Shop domain. Its more like an admin domain perhaps... 
            return Created($"/api/customer/{value.Id}", value);
        }

        // PUT: api/Customer/5
        /// <summary>
        /// Updates the information about the given user. 
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="value">The info to update the user with.</param>
        /// <returns></returns>
        public IHttpActionResult Put(Guid id, [FromBody]CustomerViewModel value)
        {
            //Unless you're an admin you're only allowed to update your own user.
            if (id != _currentUser.CustomerId && !_currentUser.User.IsInRole(UserRoles.Admin))
                return Unauthorized();

            using (_unitOfWork.BeginTransaction())
            {
                //TODO Here we should update the user using some sort of CustomerService. I am not quite sure if it belongs in the Shop domain. Its more like an admin domain perhaps...
            }
            return Ok();
        }

        // DELETE: api/Customer/5
        [Authorize(Roles = UserRoles.Admin)]
        public IHttpActionResult Delete(int id)
        {
            //TODO Here we should delete the user using some sort of CustomerService. I am not quite sure if it belongs in the Shop domain. Its more like an admin domain perhaps...
            return Ok();
        }
    }
}
