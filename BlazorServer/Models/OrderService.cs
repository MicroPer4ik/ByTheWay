using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class OrderService
    {
        public int IdOrder { get; set; }
        public int IdService { get; set; }
        public int? Count { get; set; }

        public virtual Order IdOrderNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
    }
}
