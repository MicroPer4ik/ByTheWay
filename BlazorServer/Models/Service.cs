using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Service
    {
        public Service()
        {
            IdOrders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string TitleService { get; set; } = null!;
        public decimal CostService { get; set; }
        public int IdServiceType { get; set; }

        public virtual ServiceType IdServiceTypeNavigation { get; set; } = null!;

        public virtual ICollection<Order> IdOrders { get; set; }
    }
}
