using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class Store
    {
        public Store()
        {
            Stockbalances = new HashSet<Stockbalance>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }

        public virtual ICollection<Stockbalance> Stockbalances { get; set; }
    }
}
