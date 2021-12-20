using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class AuthourView
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public int? Titles { get; set; }
        public string StockBalance { get; set; }
    }
}
