using PatientsStory.Models;
using PatientsStory.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class PatientsListViewModel : BaseViewModel
    {
        public PatientsListViewModel()
        {
            RefreshCommand.Execute(null);
        }

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                if (_selectedPatient == null)
                {
                    return;
                }
                SelectPatient.Execute(_selectedPatient);
                _selectedPatient = null;
                OnPropertyChanged("SelectedPatient");
            }
        }

        private ObservableCollection<Patient> _patientsList;
        public ObservableCollection<Patient> PatientsList
        {
            get
            {
                return _patientsList;
            }
            set
            {
                _patientsList = value;
                OnPropertyChanged("PatientsList");
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

        public Command AddPatient
        {
            get
            {
                return new Command(async () =>
                {
                    var patientAddViewModel = new PatientAddViewModel();
                    var patientAddPage = new PatientAddPage(patientAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(patientAddPage);
                });
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

        public Command SelectPatient
        {
            get
            {
                return new Command(async () =>
                {
                    var patientDetailsViewModel = InitPatientDetailsViewModel();
                    var patientDetailsPage = new PatientDetailsPage(patientDetailsViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(patientDetailsPage);
                });
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    var patients = await App.Database.GetPatientsAsync();
                    PatientsList = new ObservableCollection<Patient>(patients);
                    IsRefreshing = false;
                });
            }
        }

        #region Helpers

        private HotelInfoViewModel InitHotelInfoViewModel()
        {
            var viewModel = new HotelInfoViewModel();
            viewModel.Name = Hotel.name;
            viewModel.Address = Hotel.address;
            viewModel.Postcode = Hotel.postcode;
            viewModel.Phone = Hotel.phone;
            return viewModel;
        }

        private PatientDetailsViewModel InitPatientDetailsViewModel()
        {
            return new PatientDetailsViewModel
            {
                PatientId = _selectedPatient.PatientId,
                FirstName = _selectedPatient.FirstName,
                LastName = _selectedPatient.LastName,
                FullName = _selectedPatient.FullName,
                PESEL = _selectedPatient.PESEL,
                Age = _selectedPatient.Age.ToString(),
                Gender = _selectedPatient.Gender
            };
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