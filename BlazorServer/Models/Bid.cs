using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Bid
    {
        public Bid()
        {
            IdServices = new HashSet<Service>();
        }

        public int Id { get; set; }
        public int IdClient { get; set; }
        public DateTime DateSubmission { get; set; }
        public int IdStatus { get; set; }
        public string Description { get; set; } = null!;

        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Order IdNavigation { get; set; } = null!;
        public virtual StatusBid IdStatusNavigation { get; set; } = null!;

        public virtual ICollection<Service> IdServices { get; set; }
    }
}
