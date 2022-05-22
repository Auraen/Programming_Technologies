using View.Model;
using View.Services;
using View.Stores;
using View.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace View
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly library _library;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _library = new library();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateManageStockViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        //when on starting view, go to manage borrow view or manage stock view if cancel
        private StartingViewModel CreateStartingViewModel()
        {
            return new StartingViewModel(_library, new NavigationService(_navigationStore, CreateManageStockViewModel), new NavigationService(_navigationStore, CreateManageBorrowViewModel));
        }

        //when on addbook view, go to manage stock view
        private AddBookViewModel CreateAddBookViewModel()
        {
            return new AddBookViewModel(_library, new NavigationService(_navigationStore, CreateManageStockViewModel));
        }

        //when on deletebook view, go to manage stock view
        private DeleteBookViewModel CreateDeleteBookViewModel()
        {
            return new DeleteBookViewModel(_library, new NavigationService(_navigationStore, CreateManageStockViewModel));
        }

        //when on manage stock view, go to starting view
        private ManageStockViewModel CreateManageStockViewModel()
        {
            return new ManageStockViewModel(_library, _navigationStore, CreateAddBookViewModel, CreateDeleteBookViewModel, new NavigationService(_navigationStore, CreateStartingViewModel));
        }

        //when on manage borrow view, go to starting view
        private ManageBorrowViewModel CreateManageBorrowViewModel()
        {
            return new ManageBorrowViewModel(_library, new NavigationService(_navigationStore, CreateStartingViewModel));
        }
    }
}
