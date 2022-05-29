using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class StatusEmployee
    {
        public StatusEmployee()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
