using System.Collections.ObjectModel;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BookStore.ViewModels
{
    class AuthorsViewModel : ObservableObject
    {
        public ObservableCollection<object> Authors { get; set; }

        private object _selectedAuthor;

        public object SelectedAuthor
        {
            get => _selectedAuthor;
            set => SetProperty(ref _selectedAuthor, value);
        }
    }
}