using System;
using System.Collections.Generic;

namespace BlazorServer.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public string Blog1 { get; set; } = null!;
        public string DatePublish { get; set; } = null!;

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
    }
}
