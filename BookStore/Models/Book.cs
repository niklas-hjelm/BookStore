using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Models
{
    public partial class Book
    {
        public Book()
        {
            AuthorBooks = new HashSet<AuthorBook>();
            Stockbalances = new HashSet<Stockbalance>();
        }

        public string Isbn13 { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public double Price { get; set; }
        public DateTime Releasedate { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<AuthorBook> AuthorBooks { get; set; }
        public virtual ICollection<Stockbalance> Stockbalances { get; set; }
    }
}
