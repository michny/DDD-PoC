using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using DDD.CommercePoC.SharedKernel.Interfaces;
using DDD.CommercePoC.Shop.Core.Interfaces;
using DDD.CommercePoC.Shop.Core.Model;
using DDD.CommercePoC.Web.Infrastructure.Alerts;
using DDD.CommercePoC.Web.Models;

namespace DDD.CommercePoC.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View().WithInfo("Hej!");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var orders = _orderRepository.ManyWithOrderItems().ToList();

            using (_unitOfWork.BeginTransaction())
            {
                orders.First().AddVariant(new Variant("My-Test-product-variation-1", new Guid("22222222-2222-2222-2222-222222222222"), "testname"));
            }

            var vm = new ViewOrderListViewModel
            {
                Orders = Mapper.Map<List<ViewOrderViewModel>>(orders)
            };

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Hello()
        {
            //using (_unitOfWork.BeginTransaction())
            //{
            //    var guid = Guid.NewGuid();
            //    _orderRepository.Add(new Order(guid, new Guid("11111111-1111-1111-1111-111111111111")));
            //}
            return View();
        }
    }
}