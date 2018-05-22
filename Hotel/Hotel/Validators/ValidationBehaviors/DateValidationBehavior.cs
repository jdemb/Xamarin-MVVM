using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Hotel.Validators
{
    public class DateValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            var date = textChangedEventArgs.NewTextValue;
            var dateEntry = sender as Entry;

            if (dateIsValid(date))
            {
                dateEntry.TextColor = Color.White;
            }
            else
            {
                dateEntry.TextColor = Color.Red;
            }
        }

        public static bool dateIsValid(string date)
        {
            DateTime dt;
            bool result =  DateTime.TryParseExact( date,
                                    "dd/MM/yyyy",
                                    CultureInfo.InvariantCulture,
                                    DateTimeStyles.None,
                                    out dt);
            if (!result)
                return false;
            result = DateTime.Today < dt;
            return result;
        }
    }
}
