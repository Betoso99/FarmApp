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
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms.GoogleMaps;

namespace FarmApp.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
		public INavigationService _navigationService { get; set; }
		public IPageDialogService _dialogService { get; set; }
		public IGoogleMapsService _googleMapsService { get; set; }

		public DelegateCommand GetRouteCommand { get; set; }
		public DelegateCommand SearchCommand { get; set; }
		public DelegateCommand CurrentLocationCommand { get; set; }

		public Location CurrentLocation { get; set; }
        public ObservableCollection<Pin> Pins { get; set; }

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

			Task.Run(SetCurrentLocation).Wait();
            Pins = new ObservableCollection<Pin>();

			GetRouteCommand = new DelegateCommand(async () => await GetDataDirectionsAsync());

			SearchCommand = new DelegateCommand(async () => await OnSearchAsync());
			CurrentLocationCommand = new DelegateCommand(async () => await SetCurrentLocation());
		}

		async Task SetCurrentLocation()
        {
			try
			{
				CurrentLocation = await Geolocation.GetLastKnownLocationAsync();
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
		}

		async Task OnSearchAsync()
        {
            // Aqui va el codigo para obtener las farmacias que correspondan con el producto a buscar
            //luego se crean una lista de pins con esa info

            IList<Pin> pins = new List<Pin>();
			Pin newPin = new Pin
			{
				Type = PinType.Place,
				Position = new Position(18.495791, -69.851877),
				Label = "Current",
				Address = "Location",
				Tag = string.Empty
			};

			newPin.Clicked += OnPinClick;

			pins.Add(newPin);

			Pins = new ObservableCollection<Pin>(pins);
        }

		private async void OnPinClick(object sender, EventArgs e)
		{
			Pin pin = (Pin)sender;
			await _navigationService.NavigateAsync($"{Constants.StorePage}");
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
            {
				await _dialogService.DisplayAlertAsync("No route", "No route found", "Ok");
            }
		}

		
	}
}
