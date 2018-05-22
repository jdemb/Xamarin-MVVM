using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PatientsStory.Validators
{
    public class PESELValidationBehavior : Behavior<Entry>
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
            var pesel = textChangedEventArgs.NewTextValue;
            var peselEntry = sender as Entry;

            if (Regex.IsMatch(pesel, RegexPatterns.peselPattern))
            {
                peselEntry.TextColor = Color.Black;
            }
            else
            {
                peselEntry.TextColor = Color.Red;
            }
        }
    }
}