using FarmApp.ViewModels;
using FarmApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace FarmApp
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null)
			: base(initializer)
		{
		}

		protected override async void OnInitialized()
		{
			InitializeComponent();

			await NavigationService.NavigateAsync("HomePage");
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
			containerRegistry.RegisterForNavigation<SearchedPage, SearchedPageViewModel>();
			containerRegistry.RegisterForNavigation<StorePage, StorePageViewModel>();
			containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
		}
	}
}
