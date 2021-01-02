using FarmApp.Services;
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

			await NavigationService.NavigateAsync($"NavigationPage/{Constants.HomePage}");
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<NavigationPage>();
			containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>(Constants.HomePage);
			containerRegistry.RegisterForNavigation<StorePage, StorePageViewModel>(Constants.StorePage);
            containerRegistry.RegisterForNavigation<DirectionPage, DirectionPageViewModel>(Constants.DirectionPage);
            containerRegistry.RegisterForNavigation<InfoPage, InfoPageViewModel>(Constants.InfoPage);
            containerRegistry.RegisterForNavigation<OptionsPage, OpinionsPageViewModel>(Constants.OpinionsPage);
            containerRegistry.RegisterForNavigation<SharePage, SharePageViewModel>(Constants.SharePage);

			containerRegistry.Register<IGoogleMapsService, GoogleMapsService>();
        }
	}
}
