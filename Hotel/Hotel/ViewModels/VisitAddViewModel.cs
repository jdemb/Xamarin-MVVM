using PatientsStory.Models;
using PatientsStory.Validators;
using System;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class VisitAddViewModel : BaseViewModel
    {
        public VisitAddViewModel()
        {
            MaximumDateOfVisit = DateTime.Today;
        }

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

        private DateTime _dateOfVisit = DateTime.Today;
        public DateTime DateOfVisit
        {
            get { return _dateOfVisit; }
            set
            {
                _dateOfVisit = value;
                OnPropertyChanged("DateOfVisit");
            }
        }

        private DateTime _maximumDateOfVisit;
        public DateTime MaximumDateOfVisit
        {
            get { return _maximumDateOfVisit; }
            set
            {
                _maximumDateOfVisit = value;
                OnPropertyChanged("MaximumDateOfVisit");
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

        private Decimal _price = 0M;
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

        public Command SaveVisit
        {
            get
            {
                return new Command(async () =>
                {
                    if (AreVisitFieldsValid())
                    {
                        var visit = CreateVisit();
                        await App.Database.SaveVisitAsync(visit);
                        await Application.Current.MainPage.DisplayAlert("Zrobione!", "Dodano/zaktualizowano wizytę!", "Ok");
                        await Application.Current.MainPage.Navigation.PopToRootAsync();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Błąd!", "Popraw błędne dane!", "Ok");
                    }
                });
            }
        }

        #region Helpers

        private bool AreVisitFieldsValid()
        {
            return IsValid.Valid(Diagnose, RegexPatterns.descriptionPattern)
                   && IsValid.Valid(Indications, RegexPatterns.descriptionPattern)
                   && IsValid.Valid(Price.ToString(), RegexPatterns.pricePattern);
        }

        private Visit CreateVisit()
        {
            return new Visit
            {
                VisitId = VisitId,
                PatientId = PatientId,
                DateOfVisit = DateOfVisit,
                Diagnose = Diagnose,
                Indications = Indications,
                Price = Price
            };
        }

        #endregion
    }
}