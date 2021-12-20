using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class Stockbalance
    {
        public int StoreId { get; set; }
        public string Isbn { get; set; }
        public int Quantity { get; set; }

        public virtual Book IsbnNavigation { get; set; }
        public virtual Store Store { get; set; }
    }
}
