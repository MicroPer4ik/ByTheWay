using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int IdBid { get; set; }
        public string IdClient { get; set; } = null!;
        public decimal PriceOrder { get; set; }
        public DateTime DateBeginning { get; set; }
        public DateTime DateEnd { get; set; }
        public int IdStatus { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Bid IdB { get; set; } = null!;
        public virtual StatusOrder IdStatusNavigation { get; set; } = null!;
    }
}
