using FarmApp.Services;
using Refit;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FarmApp.Views
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
        {
			base.OnAppearing();
        }
		
	}
}
