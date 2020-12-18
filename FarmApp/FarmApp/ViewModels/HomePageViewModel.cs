using FarmApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FarmApp.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
		public INavigationService _navigationService { get; set; }
		public IPageDialogService _dialogService { get; set; }

		public DelegateCommand Nav { get; set; }
		public DelegateCommand GetRouteCommand { get; set; }

		public string OriginLongitude { get; set; }
		public string OriginLatitude { get; set; }
		public string DestinationLongitude { get; set; }
		public string DestinationLatitude { get; set; }

		public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService) :
			base(navigationService)
		{
			Title = "Home Page - Here goes the map and search input";
			_dialogService = dialogService;
			_navigationService = navigationService;

			Nav = new DelegateCommand(async()=> await NavigationExecute());
			GetRouteCommand = new DelegateCommand(async () => await GetDataDirections());
		}

		async Task GetDataDirections()
		{
			const string ApiBaseAddress = "https://maps.googleapis.com/maps/";
			var mapsAPI = RestService.For<IGoogleMapsAPIService>(ApiBaseAddress);
			var directions = await mapsAPI.GetDirections(OriginLatitude, OriginLongitude, DestinationLatitude, DestinationLongitude, Constants.GoogleMapsApiKey);

			if (directions.Routes != null && directions.Routes.Count > 0)
			{
				
			}
			else
				await _dialogService.DisplayAlertAsync("No route", "No route found", "Ok");
		}

		async Task NavigationExecute()
		{
			await _navigationService.NavigateAsync($"{Constants.StorePage}?selectedTab={Constants.InfoPage}");
		}
	}
}
