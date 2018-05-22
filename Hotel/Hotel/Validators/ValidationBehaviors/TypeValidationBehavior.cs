using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Hotel.Validators
{
    public class TypeValidationBehavior : Behavior<Entry>
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
            var type = textChangedEventArgs.NewTextValue;
            var typeEntry = sender as Entry;

            if (Regex.IsMatch(type, RegexPatterns.typePattern))
            {
                typeEntry.TextColor = Color.White;
            }
            else
            {
                typeEntry.TextColor = Color.Red;
            }
        }
    }
}
