using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShippingAdress { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
