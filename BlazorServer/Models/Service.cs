using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Models
{
    public partial class Service
    {
        public Service()
        {
            Bids = new HashSet<Bid>();
        }
        [Key]
        public int Id { get; set; }
        public string TitleService { get; set; } = null!;
        public decimal CostService { get; set; }
        public string DescriptionService { get; set; } = null!;

        public virtual ICollection<Bid> Bids { get; set; }
    }
}
