using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Hotel.Validators
{
    public class PriceValidationBehavior : Behavior<Entry>
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
            var price = textChangedEventArgs.NewTextValue;
            var priceEntry = sender as Entry;

            if (Regex.IsMatch(price, RegexPatterns.pricePattern))
            {
                priceEntry.TextColor = Color.White;
            }
            else
            {
                priceEntry.TextColor = Color.Red;
            }
        }
    }
}