using PatientsStory.Models;
using PatientsStory.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class PatientDetailsViewModel : BaseViewModel
    {
        private int _patientId;
        public int PatientId
        {
            get { return _patientId; }
            set
            {
                _patientId = value;
                OnPropertyChanged("PatientId");
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

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        private string _pesel;
        public string PESEL
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                OnPropertyChanged("PESEL");
            }
        }

        private string _age;
        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        private string _gender;
        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                SetLongNameGender();
                OnPropertyChanged("Gender");
            }
        }

        public Command EditPatient
        {
            get
            {
                return new Command(async () =>
                {
                    var patientAddViewModel = InitPatientAddViewModel();
                    var patientAddPage = new PatientAddPage(patientAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(patientAddPage);
                });
            }
        }

        public Command DeletePatient
        {
            get
            {
                return new Command(async () =>
                {
                    var answer = await Application.Current.MainPage.DisplayAlert("Usunąć?", "Czy na pewno chcesz usunąć?", "Tak", "Nie");
                    if (answer)
                    {
                        var patientAddViewModel = new PatientAddViewModel();
                        var patient = await App.Database.GetPatientAsync(PatientId);
                        await App.Database.DeletePatientAsync(patient);
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                });
            }
        }

        public Command ShowHistory
        {
            get
            {
                return new Command(async () =>
                {
                    var visitsListViewModel = await InitVisitsListViewModel();
                    var visitsListPage = new VisitsListPage(visitsListViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(visitsListPage);
                });
            }
        }

        public Command AddVisit
        {
            get
            {
                return new Command(async () =>
                {
                    var visitAddViewModel = InitVisitAddViewModel();
                    var visitAddPage = new VisitAddPage(visitAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(visitAddPage);
                });
            }
        }

        #region Helpers

        private void SetLongNameGender()
        {
            if (_gender == "M")
            {
                _gender = "Mężczyzna";
            }
            else if (_gender == "K")
            {
                _gender = "Kobieta";
            }
        }

        private PatientAddViewModel InitPatientAddViewModel()
        {
            return new PatientAddViewModel
            {
                PatientId = PatientId,
                FirstName = FirstName,
                LastName = LastName,
                PESEL = PESEL,
                Gender = Gender
            };
        }

        private async Task<VisitsListViewModel> InitVisitsListViewModel()
        {
            var visitsListViewModel = new VisitsListViewModel();
            var visits = await App.Database.GetVisitsAsync(PatientId);
            visitsListViewModel.VisitsList = new ObservableCollection<Visit>(visits);
            visitsListViewModel.PatientId = PatientId;
            visitsListViewModel.PatientFullName = FullName;
            return visitsListViewModel;
        }

        private VisitAddViewModel InitVisitAddViewModel()
        {
            return new VisitAddViewModel
            {
                PatientId = PatientId,
                PatientFullName = FullName
            };
        }

        #endregion
    }
}