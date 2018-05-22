using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Hotel.Validators
{
    public class AmountOfBedsValidationBehavior : Behavior<Entry>
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
            var amountOfBeds = textChangedEventArgs.NewTextValue;
            var amountOfBedsEntry = sender as Entry;

            if (Regex.IsMatch(amountOfBeds, RegexPatterns.amountOfBedspattern))
            {
                amountOfBedsEntry.TextColor = Color.White;
            }
            else
            {
                amountOfBedsEntry.TextColor = Color.Red;
            }
        }
    }
}
