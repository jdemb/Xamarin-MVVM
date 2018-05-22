using Hotel.Database;
using Hotel.Helpers;
using Hotel.Models;
using Hotel.ViewModels;
using Hotel.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Hotel
{
    public partial class App : Application
    {
        private static DatabaseController _database;
        private DateTime _sleepStart;
        private readonly TimeSpan _sleepLimit;

        public App()
        {
            InitializeComponent();
            var list = Database.GetAttractionsAsync().Result;
            if(list.Count == 0)
                Database.loadAttractions();
            MainPage = new NavigationPage(new AttractionListPage(InitAttractionListViewModel()));
            _sleepLimit = TimeSpan.FromMinutes(30);
        }

        private AttractionListViewModel InitAttractionListViewModel()
        {
            var viewModel = new AttractionListViewModel();
            var list = Database.GetAttractionsAsync().Result;
            viewModel.AttractionsList = new ObservableCollection<Attraction>(list);
            viewModel.IsReservationsListEmpty = Database.CheckIfReservationIsEmpty();
            return viewModel;
        }

        public static DatabaseController Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DatabaseController(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("database.db7"));
                }
                return _database;
            }
        }

        protected override void OnSleep()
        {
            _sleepStart = DateTime.Now;
        }

        protected override void OnResume()
        {
            if (DateTime.Now - _sleepStart > _sleepLimit)
            {
                MessagingCenter.Send(this, "The session has expired.");
            }
        }
    }
}