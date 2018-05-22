using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace PatientsStory.Validators
{
    public class GenderValidationBehavior : Behavior<Entry>
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
            var gender = textChangedEventArgs.NewTextValue;
            var genderEntry = sender as Entry;

            if (Regex.IsMatch(gender, RegexPatterns.genderPattern))
            {
                genderEntry.TextColor = Color.Black;
            }
            else
            {
                genderEntry.TextColor = Color.Red;
            }
        }
    }
}