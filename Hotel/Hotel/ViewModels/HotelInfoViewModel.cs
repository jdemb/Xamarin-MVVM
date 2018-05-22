using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hotel.ViewModels
{
    public class HotelInfoViewModel : BaseViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        private string _postcode;
        public string Postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                OnPropertyChanged("Postcode");
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public Command Call
        {
            get
            {
                return new Command(async () =>
                {
                    var answer = await Application.Current.MainPage.DisplayAlert("", "Czy chcesz zadzwonić do obsługi klienta?", "Tak", "Nie");
                    if (answer)
                    {
                        var dialer = DependencyService.Get<IDialer>();
                        if (dialer != null)
                            dialer.Dial(Phone);
                    }
                });
            }
        }
    }
}
