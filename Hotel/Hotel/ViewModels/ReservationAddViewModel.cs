using Hotel.Models;
using Hotel.Validators;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Hotel.ViewModels
{
    public class ReservationAddViewModel : BaseViewModel
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

        public Command SaveReservation
        {
            get
            {
                return new Command(async () =>
                {
                    if (AreReservationFieldsValid())
                    {
                        var reservation = CreateReservation();
                        await App.Database.SaveReservationAsync(reservation);
                        await Application.Current.MainPage.DisplayAlert("Rezerwacja pomyślna", "Dokonano rezerwacji", "Ok");
                        var mainPage = new AttractionListPage(InitAtractionListViewModel());
                        await Application.Current.MainPage.Navigation.PushAsync(mainPage);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Błąd!", "Podane dane są niepoprawne lub rezerwacja w tym okresie jest niedostępna", "Ok");
                    }
                });
            }
        }

        #region Helpers

        private AttractionListViewModel InitAtractionListViewModel()
        {
            var viewModel = new AttractionListViewModel();
            var list = App.Database.GetAttractionsAsync().Result;
            viewModel.AttractionsList = new ObservableCollection<Attraction>(list);
            viewModel.IsReservationsListEmpty = App.Database.CheckIfReservationIsEmpty();
            return viewModel;
        }

        private bool AreReservationFieldsValid()
        {
            return IsValid.Valid(FirstName, RegexPatterns.namePattern)
                   && IsValid.Valid(LastName, RegexPatterns.namePattern)
                   && DateTime.Today < StartDate
                   && DateTime.Today < EndDate
                   && IsValid.Valid(AmountOfBeds.ToString(), RegexPatterns.amountOfBedspattern)
                   && IsValid.Valid(Type, RegexPatterns.typePattern);
        }

        private Reservation CreateReservation()
        {
            return new Reservation
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
