﻿using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BookStore.Managers
{
    class NavigationManager
    {
        private ObservableObject _currentViewModel;

        public ObservableObject CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
