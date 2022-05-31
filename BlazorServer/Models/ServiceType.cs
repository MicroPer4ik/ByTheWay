using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string TypeTitle { get; set; } = null!;

        public virtual ICollection<Service> Services { get; set; }
    }
}
