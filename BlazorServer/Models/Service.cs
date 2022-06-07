using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Service
    {
        public Service()
        {
            OrderServices = new HashSet<OrderService>();
        }

        public int Id { get; set; }
        public string TitleService { get; set; } = null!;
        public decimal CostService { get; set; }
        public int IdServiceType { get; set; }

        public virtual ServiceType IdServiceTypeNavigation { get; set; } = null!;

        public virtual ICollection<OrderService> OrderServices { get; set; }
    }
}
