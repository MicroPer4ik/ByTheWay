using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class StatusBid
    {
        public StatusBid()
        {
            Bids = new HashSet<Bid>();
        }

        public int Id { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<Bid> Bids { get; set; }
    }
}
