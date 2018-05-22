using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Hotel.Validators.ValidationBehaviors
{
    public class AmountValidationBehavior : Behavior<Entry>
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
            var amount = textChangedEventArgs.NewTextValue;
            var amountEntry = sender as Entry;

            if (Regex.IsMatch(amount, RegexPatterns.amountOfBedspattern))
            {
                amountEntry.TextColor = Color.White;
            }
            else
            {
                amountEntry.TextColor = Color.Red;
            }
        }
    }
}
