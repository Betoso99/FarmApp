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

			await NavigationService.NavigateAsync($"{Constants.LogsPage}");

		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			// Navigation

			containerRegistry.RegisterForNavigation<NavigationPage>(Constants.NavigationPage);
			containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>(Constants.HomePage);
			containerRegistry.RegisterForNavigation<StorePage, StorePageViewModel>(Constants.StorePage);
            containerRegistry.RegisterForNavigation<InfoPage, InfoPageViewModel>(Constants.InfoPage);
            containerRegistry.RegisterForNavigation<OpinionsPage, OpinionPageViewModel>(Constants.OpinionsPage);
            containerRegistry.RegisterForNavigation<SharePage, SharePageViewModel>(Constants.SharePage);
			containerRegistry.RegisterForNavigation<LogsPage, LogsPageViewModel>(Constants.LogsPage);
			containerRegistry.RegisterForNavigation<InventoryPage, InventoryPageViewModel>(Constants.InventoryPage);

			// Services

			containerRegistry.Register<IGoogleMapsService, GoogleMapsService>();
			containerRegistry.Register<IFarmAppService, FarmAppService>();
			containerRegistry.Register<IDialogService, DialogService>();

		}
	}
}
