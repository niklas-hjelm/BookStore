using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Managers
{
    class BookStoreManager
    {
        public ICollection<Author> Authors { get; set; }

        public ICollection<Store> Stores { get; set; }

        public BookStoreManager()
        {
            using (var context = new BookstoreContext())
            {
                Authors = context.Authors.ToList();
                Stores = context.Stores.ToList();
                var books = context.Books.ToList();

                foreach (var author in Authors)
                {
                    var authorBooks = books.Where(book => book.AuthorId == author.Id);
                    foreach (var authorBook in authorBooks)
                    {
                        author.Books.Add(authorBook);
                    }
                }

                var stockBalances = context.Stockbalances.ToList();

                foreach (var store in Stores)
                {
                    var storeStockBalance = stockBalances.Where(bal => bal.StoreId == store.StoreId);
                    foreach (var stockbalance in storeStockBalance)
                    {
                        store.Stockbalances.Add(stockbalance);
                    }
                }
            }
        }

        public ICollection<BookQuantity> GetBooksInStore(int storeID)
        {
            var booksInStore = new List<BookQuantity>();

            using (var context = new BookstoreContext())
            {
                var stockBalances = context.Stockbalances.Where(s=>s.StoreId == storeID).ToList(); 
                var books = context.Books.ToList();
                foreach (var stockbalance in stockBalances)
                {
                    var book = books.Find(b => b.Isbn13 == stockbalance.Isbn);
                    booksInStore.Add(new BookQuantity(){Title = book.Title, Quantity = stockbalance.Quantity , Isbn = book.Isbn13});
                }
            }

            return booksInStore;
        }
    }
}
