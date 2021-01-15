using FarmApp.Services;
using FarmApp.ViewModels;
using Prism.Navigation;
using Xamarin.Forms;

namespace FarmApp.Views
{
	public partial class StorePage : TabbedPage
	{
		public StorePage()
		{
			InitializeComponent();

			//var storePageViewModel = (StorePageViewModel)this.BindingContext;

			//int pharmacyId = storePageViewModel.PharmacyId;

			// TODO: logic to pass the pharmacyId paramater into the other pages
		}
	}
}
