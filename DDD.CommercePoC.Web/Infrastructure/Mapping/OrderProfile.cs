using AutoMapper;
using DDD.CommercePoC.Shop.Core.Model;
using DDD.CommercePoC.Web.Models;

namespace DDD.CommercePoC.Web.Infrastructure.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, ViewOrderViewModel>()
                .ForMember(dest => dest.CustomerName, opt => opt.ResolveUsing((src, dest) => src.Customer?.Name));

            CreateMap<OrderItem, ViewOrderItemViewModel>()
                .ForMember(dest => dest.VariantName, opt => opt.ResolveUsing((src, dest) => src.Variant?.Name));
        }
    }
}