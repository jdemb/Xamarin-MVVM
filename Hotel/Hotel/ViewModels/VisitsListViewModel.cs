using PatientsStory.Models;
using PatientsStory.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class VisitsListViewModel : BaseViewModel
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

        private string _patientFullName;
        public string PatientFullName
        {
            get { return _patientFullName; }
            set
            {
                _patientFullName = value;
                OnPropertyChanged("PatientFullName");
            }
        }

        private Visit _selectedVisit;
        public Visit SelectedVisit
        {
            get { return _selectedVisit; }
            set
            {
                _selectedVisit = value;
                if (_selectedVisit == null)
                {
                    return;
                }
                SelectVisit.Execute(_selectedVisit);
                _selectedVisit = null;
                OnPropertyChanged("SelectedVisit");
            }
        }

        private ObservableCollection<Visit> _visitsList;
        public ObservableCollection<Visit> VisitsList
        {
            get
            {
                return _visitsList;
            }
            set
            {
                _visitsList = value;
                OnPropertyChanged("VisitsList");
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

        public Command SelectVisit
        {
            get
            {
                return new Command(async () =>
                {
                    var visitDetailsViewModel = InitVisitDetailsViewModel();
                    var visitDetailsPage = new VisitDetailsPage(visitDetailsViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(visitDetailsPage);
                });
            }
        }

        #region Helpers

        private VisitAddViewModel InitVisitAddViewModel()
        {
            return new VisitAddViewModel
            {
                PatientId = PatientId,
                PatientFullName = PatientFullName
            };
        }

        private VisitDetailsViewModel InitVisitDetailsViewModel()
        {
            return new VisitDetailsViewModel
            {
                VisitId = _selectedVisit.VisitId,
                PatientId = _selectedVisit.PatientId,
                DateOfVisit = _selectedVisit.DateOfVisit,
                Diagnose = _selectedVisit.Diagnose,
                Indications = _selectedVisit.Indications,
                Price = _selectedVisit.Price,
                PatientFullName = PatientFullName
            };
        }

        #endregion
    }
}