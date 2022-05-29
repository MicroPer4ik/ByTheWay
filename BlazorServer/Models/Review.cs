using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public string ReviewText { get; set; } = null!;
        public DateTime DatePublish { get; set; }

        public virtual Client IdClientNavigation { get; set; } = null!;
    }
}
