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
			_dialogService = dialogService;
			Title = "Home Page";
			_navigationService = navigationService;
			Nav = new DelegateCommand(NavigationExecute);

			GetRouteCommand = new DelegateCommand(async () => await GetDataDirections(_dialogService));
		}

		async Task GetDataDirections(IPageDialogService dialogService)
		{
			const string ApiBaseAddress = "https://maps.googleapis.com/maps/";
			var mapsAPI = RestService.For<IGoogleMapsAPIService>(ApiBaseAddress);
			var directions = await mapsAPI.GetDirections(OriginLatitude, OriginLongitude, DestinationLatitude, DestinationLongitude, Constants.GoogleMapsApiKey);

			if (directions.Routes != null && directions.Routes.Count > 0)
			{
				//var positions = Enumerable.ToList(PolylineHelper.Decode(directions.Routes.First().OverviewPolyline.Points));
				//CalculateRouteCommand.Execute(positions);

				//Location tracking simulation
				//Device.StartTimer(TimeSpan.FromSeconds(1), () =>
				//{
					//if (positions.Count > positionIndex)
					//{
					//	UpdatePositionCommand.Execute(positions[positionIndex]);
					//	positionIndex++;
					//	return true;
					//}
					//else
					//{
						//return false;
					//}
				//});
			}
			else
				await dialogService.DisplayAlertAsync("No route", "No route found", "Ok");
		}

		async void NavigationExecute()
		{
			await _navigationService.NavigateAsync("SearchedPage");
		}
	}
}
