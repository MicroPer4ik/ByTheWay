using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Blogs = new HashSet<Blog>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdStatus { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Patronymic { get; set; } = null!;

        public virtual StatusEmployee IdStatusNavigation { get; set; } = null!;
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
