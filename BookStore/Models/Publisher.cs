using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class Publisher
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Publisher1 { get; set; }

        public virtual Book Book { get; set; }
    }
}
