using FarmApp.ViewModels;
using FarmApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace FarmApp
{
	public partial class App
	{
		public App(IPlatformInitializer initializer)
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
			containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
		}
	}
}
