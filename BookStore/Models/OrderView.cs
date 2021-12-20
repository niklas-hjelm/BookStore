using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class OrderView
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string PurchasedBooks { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerAdress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int OrderId { get; set; }
    }
}
