using Hotel.Models;
using Hotel.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Hotel.ViewModels
{
    public class AttractionListViewModel : BaseViewModel
    {
        private ObservableCollection<Attraction> _attractionsList;
        public ObservableCollection<Attraction> AttractionsList
        {
            get
            {
                return _attractionsList;
            }
            set
            {
                _attractionsList = value;
                OnPropertyChanged("AttractionsList");
            }
        }

        private ObservableCollection<Reservation> _reservationList;
        public ObservableCollection<Reservation> ReservationList
        {
            get
            {
                return _reservationList;
            }
            set
            {
                _reservationList = value;
                OnPropertyChanged("ReservationList");
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        private bool _isReservationsListEmpty;
        public bool IsReservationsListEmpty
        {
            get { return _isReservationsListEmpty; }
            set
            {
                _isReservationsListEmpty = value;
                MIRRIsReservationsListEmpty = !value;
                OnPropertyChanged("IsReservationsListEmpty");
            }
        }

        private bool _MIRRisReservationsListEmpty;
        public bool MIRRIsReservationsListEmpty
        {
            get { return _MIRRisReservationsListEmpty; }
            set
            {
                _MIRRisReservationsListEmpty = value;
                OnPropertyChanged("MIRRIsReservationsListEmpty");
            }
        }

        public Command HotelInfo
        {
            get
            {
                return new Command(async () =>
                {
                    var hotelViewModel = InitHotelInfoViewModel();
                    var hotelPage = new HotelInfoPage(hotelViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(hotelPage);
                });
            }
        }

        public Command Reservation
        {
            get
            {
                return new Command(async () =>
                {
                    var reservationAddViewModel = new ReservationAddViewModel();
                    var reservationAddPage = new ReservationAddPage(reservationAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(reservationAddPage);
                    IsReservationsListEmpty = App.Database.CheckIfReservationIsEmpty();
                });
            }
        }

        public Command Price
        {
            get
            {
                return new Command(async () =>
                {
                    var priceViewModel = new PriceViewModel();
                    var pricePage = new PricePage(priceViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(pricePage);
                    IsReservationsListEmpty = App.Database.CheckIfReservationIsEmpty();
                });
            }
        }

        public Command ReservationDet
        {
            get
            {
                return new Command(async () =>
                {
                    var reservations = await App.Database.GetReservationsAsync();
                    ReservationList = new ObservableCollection<Reservation>(reservations);
                    var reservationDetailsViewModel = InitReservationDetailsViewModel();
                    var reservationPage = new ReservationPage(reservationDetailsViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(reservationPage);
                    IsReservationsListEmpty = App.Database.CheckIfReservationIsEmpty();
                });
            }
        }

        #region Helpers

        private HotelInfoViewModel InitHotelInfoViewModel()
        {
            var viewModel = new HotelInfoViewModel();
            viewModel.Name = Models.Hotel.name;
            viewModel.Address = Models.Hotel.address;
            viewModel.Postcode = Models.Hotel.postcode;
            viewModel.Phone = Models.Hotel.phone;
            return viewModel;
        }

        private ReservationDetailsViewModel InitReservationDetailsViewModel()
        {
            return new ReservationDetailsViewModel
            {
                ReservationId = ReservationList[0].ReservationId,
                FirstName = ReservationList[0].FirstName,
                LastName = ReservationList[0].LastName,
                Type = ReservationList[0].Type,
                StartDate = ReservationList[0].StartDate,
                EndDate = ReservationList[0].EndDate,
                AmountOfBeds = ReservationList[0].AmountOfBeds
            };
        }

        #endregion
    }
}
