using System.Collections.ObjectModel;
using BookStore.Managers;
using BookStore.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BookStore.ViewModels
{
    class StockViewModel : ObservableObject
    {
        private readonly BookStoreManager _bookStoreManager;

        public ObservableCollection<Store> Stores { get; set; } = new();
        public ObservableCollection<BookQuantity> StoreBooks { get; set; } = new();

        private Store _selectedStore;

        public Store SelectedStore
        {
            get { return _selectedStore; }
            set
            {
                SetProperty(ref _selectedStore, value);
                StoreBooks.Clear();
                foreach (var book in _bookStoreManager.GetBooksInStore(_selectedStore.StoreId))
                {
                    StoreBooks.Add(book);
                }
                
            }
        }

        public StockViewModel(BookStoreManager bookStoreManager)
        {
            _bookStoreManager = bookStoreManager;
            foreach (var store in _bookStoreManager.Stores)
            {
                Stores.Add(store);
            }
        }
    }
}