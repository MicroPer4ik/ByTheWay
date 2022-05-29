using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Client
    {
        public Client()
        {
            Bids = new HashSet<Bid>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Address { get; set; } = null!;

        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
