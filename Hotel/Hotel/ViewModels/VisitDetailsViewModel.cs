using PatientsStory.Views;
using System;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class VisitDetailsViewModel : BaseViewModel
    {
        private int _visitId;
        public int VisitId
        {
            get { return _visitId; }
            set
            {
                _visitId = value;
                OnPropertyChanged("VisitId");
            }
        }

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

        private DateTime _dateOfVisit;
        public DateTime DateOfVisit
        {
            get { return _dateOfVisit; }
            set
            {
                _dateOfVisit = value;
                OnPropertyChanged("DateOfVisit");
            }
        }

        private string _diagnose;
        public string Diagnose
        {
            get { return _diagnose; }
            set
            {
                _diagnose = value;
                OnPropertyChanged("Diagnose");
            }
        }

        private string _indications;
        public string Indications
        {
            get { return _indications; }
            set
            {
                _indications = value;
                OnPropertyChanged("Indications");
            }
        }

        private Decimal _price;
        public Decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
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

        public Command EditVisit
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

        private VisitAddViewModel InitVisitAddViewModel()
        {
            return new VisitAddViewModel
            {
                VisitId = VisitId,
                PatientId = PatientId,
                DateOfVisit = DateOfVisit,
                Diagnose = Diagnose,
                Indications = Indications,
                Price = Price,
                PatientFullName = PatientFullName
            };
        }

        #endregion
    }
}