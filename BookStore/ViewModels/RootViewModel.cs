using BookStore.Managers;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BookStore.ViewModels
{
    class RootViewModel : ObservableObject
    {
        private readonly NavigationManager _navigationManager;
        private readonly BookStoreManager _bookStoreManager;

        #region Commands

        public IRelayCommand NavigateStockCommand { get; }
        public IRelayCommand NavigateAuthorsCommand { get; }

        #endregion

        public ObservableObject CurrentViewModel => _navigationManager.CurrentViewModel;

        public RootViewModel(NavigationManager navigationManager, BookStoreManager bookStoreManager)
        {
            _navigationManager = navigationManager;
            _bookStoreManager = bookStoreManager;

            NavigateStockCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new StockViewModel(_bookStoreManager));
            NavigateAuthorsCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new AuthorsViewModel(_bookStoreManager));

            _navigationManager.CurrentViewModelChanged += CurrentViewModelChanged;
        }

        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
