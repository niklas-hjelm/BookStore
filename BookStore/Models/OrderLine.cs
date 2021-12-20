using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class OrderLine
    {
        public int OrderLineId { get; set; }
        public int OrderId { get; set; }
        public string Isbn { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
    }
}
