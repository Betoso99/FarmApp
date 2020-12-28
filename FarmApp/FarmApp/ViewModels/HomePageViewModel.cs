using FarmApp.Helpers;
using FarmApp.Models;
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
using Xamarin.Essentials;

namespace FarmApp.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
		public INavigationService _navigationService { get; set; }
		public IPageDialogService _dialogService { get; set; }
		public IGoogleMapsService _googleMapsService { get; set; }

		public DelegateCommand Nav { get; set; }
		public DelegateCommand GetRouteCommand { get; set; }

		public string OriginLongitude { get; set; }
		public string OriginLatitude { get; set; }
		public string DestinationLongitude { get; set; }
		public string DestinationLatitude { get; set; }

		public HomePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IGoogleMapsService googleMapsService) :
			base(navigationService)
		{
			_dialogService = dialogService;
			_navigationService = navigationService;
			_googleMapsService = googleMapsService;

			Nav = new DelegateCommand(async()=> await NavigationExecute());
			GetRouteCommand = new DelegateCommand(async () => await GetDataDirectionsAsync());
		}

		async Task GetDataDirectionsAsync()
		{
			if (Connectivity.NetworkAccess != NetworkAccess.Internet)
			{
				await _dialogService.DisplayAlertAsync("Error", "Please check your internet connection", "Ok");
				return;
			}

			GoogleDirection directions = await _googleMapsService.GetDirectionAsync(OriginLatitude, OriginLongitude, DestinationLatitude, DestinationLongitude);

			if (directions?.Routes != null && directions.Routes.Count > 0)
			{
				var positions = (Enumerable.ToList(PolylineHelper.Decode(directions.Routes.First().OverviewPolyline.Points)));
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
