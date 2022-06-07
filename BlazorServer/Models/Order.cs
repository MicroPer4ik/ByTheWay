using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Models
{
    public partial class Order
    {

        public Order()
        {
            OrderServices = new HashSet<OrderService>();
        }

        public int Id { get; set; }
        public decimal PriceOrder { get; set; } = 0;
        public DateTime DateSubmission { get; set; } = DateTime.Now;
        public DateTime? DateBeginning { get; set; }
        public DateTime? DateEnd { get; set; }
        public int IdStatus { get; set; } = 1;
        public int? EmployeeId { get; set; }
        public int IdClient { get; set; }
        public string? Description { get; set; }

        public virtual Employee? Employee { get; set; }
        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual OrderStatus IdStatusNavigation { get; set; } = null!;

        public virtual ICollection<OrderService> OrderServices { get; set; }
        [NotMapped]
        public int ServiceId { get; set; }

        [NotMapped]
        public List<Service> ServiceList { get; set; } = new List<Service>();
    }
}
