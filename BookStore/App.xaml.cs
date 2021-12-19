using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BookStore.Managers;
using BookStore.ViewModels;
using BookStore.Views;

namespace BookStore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationManager _navigationManager;

        public App()
        {
            _navigationManager = new NavigationManager();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationManager.CurrentViewModel = new StockViewModel();
            var rootWindow = new RootWindow { DataContext = new RootViewModel(_navigationManager) };
            rootWindow.Show();
            base.OnStartup(e);
        }
    }
}
