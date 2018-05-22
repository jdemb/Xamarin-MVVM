using Hotel.Models;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Hotel.ViewModels
{
    public class ReservationDetailsViewModel : BaseViewModel
    {
        private int _reservationId;
        public int ReservationId
        {
            get { return _reservationId; }
            set
            {
                _reservationId = value;
                OnPropertyChanged("ReservationId");
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        private DateTime _startDate = DateTime.Today.AddDays(1);
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private int _amountOfBeds = 2;
        public int AmountOfBeds
        {
            get { return _amountOfBeds; }
            set
            {
                _amountOfBeds = value;
                OnPropertyChanged("AmountOfBeds");
            }
        }

        private DateTime _endDate = DateTime.Today.AddDays(2);
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public Command EditReservation
        {
            get
            {
                return new Command(async () =>
                {
                    var reservationAddViewModel = InitReservationAddViewModel();
                    var reservationAddPage = new ReservationAddPage(reservationAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(reservationAddPage);
                });
            }
        }

        public Command DeleteReservation
        {
            get
            {
                return new Command(async () =>
                {
                    var answer = await Application.Current.MainPage.DisplayAlert("Usunąć?", "Czy na pewno chcesz odwołać rezerwację?", "Tak", "Nie");
                    if (answer)
                    {
                        var reservation = await App.Database.GetReservationAsync(ReservationId);
                        await App.Database.DeleteReservationAsync(reservation);
                        var mainPage = new AttractionListPage(InitAttractionListViewModel());
                        await Application.Current.MainPage.Navigation.PushAsync(mainPage);
                    }
                });
            }
        }

        #region Helpers

        private AttractionListViewModel InitAttractionListViewModel()
        {
            var viewModel = new AttractionListViewModel();
            var list = App.Database.GetAttractionsAsync().Result;
            viewModel.AttractionsList = new ObservableCollection<Attraction>(list);
            viewModel.IsReservationsListEmpty = App.Database.CheckIfReservationIsEmpty();
            return viewModel;
        }
        private ReservationAddViewModel InitReservationAddViewModel()
        {
            return new ReservationAddViewModel
            {
                ReservationId = ReservationId,
                FirstName = FirstName,
                LastName = LastName,
                Type = Type,
                StartDate = StartDate,
                EndDate = EndDate,
                AmountOfBeds = AmountOfBeds
            };
        }

        #endregion
    }
}
