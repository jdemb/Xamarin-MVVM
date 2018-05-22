using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Hotel.Validators
{
    public class NameValidationBehavior : Behavior<Entry>
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
            var name = textChangedEventArgs.NewTextValue;
            var nameEntry = sender as Entry;

            if (Regex.IsMatch(name, RegexPatterns.namePattern))
            {
                nameEntry.TextColor = Color.White;
            }
            else
            {
                nameEntry.TextColor = Color.Red;
            }
        }
    }
}