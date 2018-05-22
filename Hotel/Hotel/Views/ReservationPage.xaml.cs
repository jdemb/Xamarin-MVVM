using Hotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hotel.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReservationPage : ContentPage
	{
		public ReservationPage (ReservationDetailsViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = viewModel;
        }
	}
}