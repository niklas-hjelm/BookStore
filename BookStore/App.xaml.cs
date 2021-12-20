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
        private readonly BookStoreManager _bookStoreManager;

        public App()
        {
            _navigationManager = new NavigationManager();
            _bookStoreManager = new BookStoreManager();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationManager.CurrentViewModel = new StockViewModel(_bookStoreManager);
            var rootWindow = new RootWindow { DataContext = new RootViewModel(_navigationManager, _bookStoreManager) };
            rootWindow.Show();
            base.OnStartup(e);
        }
    }
}
