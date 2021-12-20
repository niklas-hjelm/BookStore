using System.Collections.ObjectModel;
using BookStore.Managers;
using BookStore.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BookStore.ViewModels
{
    class AuthorsViewModel : ObservableObject
    {
        public ObservableCollection<Author> Authors { get; set; } = new();
        public ObservableCollection<Book> SelectedAuthorBooks { get; set; } = new();

        private BookStoreManager _bookStoreManager;

        private Author _selectedAuthor;
        public Author SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                if (value != null && value != _selectedAuthor)
                {
                    _selectedAuthor = value;
                    OnPropertyChanged(nameof(SelectedAuthor));
                    SelectedAuthorBooks.Clear();
                    foreach (var selectedAuthorBook in _selectedAuthor.Books)
                    {
                        SelectedAuthorBooks.Add(selectedAuthorBook);
                    }
                }
            }
        }

        public AuthorsViewModel(BookStoreManager bookStoreManager)
        {
            _bookStoreManager = bookStoreManager;

            foreach (var author in _bookStoreManager.Authors)
            {
                Authors.Add(author);
            }
        }

    }
}