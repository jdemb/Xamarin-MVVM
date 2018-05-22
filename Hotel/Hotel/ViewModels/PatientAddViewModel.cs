using PatientsStory.Helpers;
using PatientsStory.Models;
using PatientsStory.Validators;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class PatientAddViewModel : BaseViewModel
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

        private int _age;
        public int Age
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
            get { return _gender; }
            set
            {
                _gender = value;
                SetShortNameGender();
                OnPropertyChanged("Gender");
            }
        }

        public Command SavePatient
        {
            get
            {
                return new Command(async () =>
                {
                    if (ArePatientFieldsValid())
                    {
                        var patient = CreatePatient();
                        await App.Database.SavePatientAsync(patient);
                        await Application.Current.MainPage.DisplayAlert("Zrobione!", "Dodano/zaktualizowano pacjenta!", "Ok");
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

        private void SetShortNameGender()
        {
            if (_gender == "Mężczyzna")
            {
                _gender = "M";
            }
            else if (_gender == "Kobieta")
            {
                _gender = "K";
            }
        }

        private bool ArePatientFieldsValid()
        {
            return IsValid.Valid(FirstName, RegexPatterns.namePattern)
                   && IsValid.Valid(LastName, RegexPatterns.namePattern)
                   && IsValid.Valid(PESEL, RegexPatterns.peselPattern)
                   && IsValid.Valid(Gender, RegexPatterns.genderPattern);
        }

        private Patient CreatePatient()
        {
            return new Patient
            {
                PatientId = PatientId,
                FirstName = FirstName,
                LastName = LastName,
                FullName = LastName + " " + FirstName,
                PESEL = PESEL,
                Age = CountAgeHelper.CountAge(PESEL),
                Gender = Gender
            };
        }

        #endregion
    }
}