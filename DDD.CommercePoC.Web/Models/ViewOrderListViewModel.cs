using System.Collections.Generic;

namespace DDD.CommercePoC.Web.Models
{
    public class ViewOrderListViewModel : BaseViewModel
    {
        public IEnumerable<ViewOrderViewModel> Orders { get; set; }
    }
}