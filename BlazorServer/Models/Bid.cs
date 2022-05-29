using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Bid
    {
        public Bid()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int IdClient { get; set; }
        public int IdService { get; set; }
        public DateTime DateSubmission { get; set; }
        public DateTime DatePerfomance { get; set; }
        public int IdStatus { get; set; }
        public string Description { get; set; } = null!;

        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
        public virtual StatusBid IdStatusNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
