using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Managers;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace BookStore.ViewModels
{
    class RootViewModel : ObservableObject
    {
        private readonly NavigationManager _navigationManager;

        #region Commands

        public IRelayCommand NavigateStockCommand { get; }
        public IRelayCommand NavigateAuthorsCommand { get; }

        #endregion

        public ObservableObject CurrentViewModel => _navigationManager.CurrentViewModel;

        public RootViewModel(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;

            NavigateStockCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new StockViewModel());
            NavigateAuthorsCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new AuthorsViewModel());

            _navigationManager.CurrentViewModelChanged += CurrentViewModelChanged;
        }


        private void CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}
