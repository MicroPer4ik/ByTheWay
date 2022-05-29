using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class StatusOrder
    {
        public StatusOrder()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
