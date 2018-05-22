using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hotel.ViewModels
{
    public class PriceViewModel : BaseViewModel
    {
        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
                setPrice();
            }
        }

        private string _priceString;
        public string PriceString
        {
            get { return _priceString; }
            set
            {
                _priceString = value;
                OnPropertyChanged("PriceString");
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
                setPrice();
            }
        }

        private int _amountOfBeds;
        public int AmountOfBeds
        {
            get { return _amountOfBeds; }
            set
            {
                _amountOfBeds = value;
                OnPropertyChanged("AmountOfBeds");
                setPrice();
            }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
                PriceString = _price.ToString() + " zł";
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
                setPrice();
            }
        }

        #region helpers

        public void setPrice()
        {
            int days = (EndDate - StartDate).Days;
            double price = 120 * AmountOfBeds * days;
            if (Type == "GOLD")
                price *= 3;
            else if (Type == "SILVER")
                price *= 2;
            Price = price;
       }

        #endregion
    }
}
