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

        #region Services
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly IGoogleMapsService _googleMapsService;
        private readonly IFarmAppService _farmAppService;
        private readonly IDialogService _dialogService;

        #endregion

        #region Commands
        public DelegateCommand GetRouteCommand { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand CurrentLocationCommand { get; set; }
        public DelegateCommand LogoutCommand { get; set; }
        #endregion

        #region Models
        public Location CurrentLocation { get; set; }
        public ObservableCollection<Pin> Pins { get; set; }
        public ObservableCollection<Product> Products { get; set; }

        #endregion

        public string LocationImage => "location.png";
        public string LogoutImage => "back_arrow.png";

        public string OriginLongitude { get; set; }
        public string OriginLatitude { get; set; }
        public string DestinationLongitude { get; set; }
        public string DestinationLatitude { get; set; }

        public string EntryText { get; set; }

        #region Constants
        const string NoInternetConnectionAlertTitle = "Connection Error";
        const string NoInternetConnectionAlertDescription = "Please check your internet connection";

        const string NoRouteAlertTitle = "No route";
        const string NoRouteAlertDescription = "No route found";
        #endregion

        
        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGoogleMapsService googleMapsService, 
            IFarmAppService farmAppService, IDialogService dialogService)
            :base(navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
            _googleMapsService = googleMapsService;
            _farmAppService = farmAppService;
            _dialogService = dialogService;

            CurrentLocation = null;
            Pins = null;
            SetCurrentLocation();
            getProducts();

            GetRouteCommand = new DelegateCommand(async () => await GetDataDirectionsAsync());
            SearchCommand = new DelegateCommand(async () => await OnSearchAsync());
            LogoutCommand = new DelegateCommand(async () => await OnLogout());
            CurrentLocationCommand = new DelegateCommand(SetCurrentLocation);
        }

        void SetCurrentLocation()
        {
            try
            {
                var task = Geolocation.GetLocationAsync();
                task.ContinueWith(location =>
                {
                    CurrentLocation = location.Result;

                    if (location != null)
                        CurrentLocation = CurrentLocation;

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                CurrentLocation = CurrentLocation;
            }
        }

        void getProducts()
        {
            try
            {
                var task = _farmAppService.GetAllProductsAsync();
                task.ContinueWith(products =>
                {
                    Products = new ObservableCollection<Product>(products.Result);

                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            
        }


        private async Task OnSearchAsync()
        {
            if (string.IsNullOrEmpty(EntryText))
            {
                Pins = new ObservableCollection<Pin>();
                return;
            }

            _dialogService.ShowLoading("Loading");
            Product product = await _farmAppService.GetProductByNameAsync(EntryText);

            if (product != null)
            {
                IList<Pharmacy> pharmacies = await _farmAppService.GetProductPharmaciesAsync(product.Id);

                IList<Pin> pins = new List<Pin>();

                foreach (Pharmacy pharmacy in pharmacies)
                {
                    Pin pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(decimal.ToDouble(pharmacy.Longitude), decimal.ToDouble(pharmacy.Latitude)),
                        Label = pharmacy.Name,
                        Address = pharmacy.Address,
                        Tag = pharmacy.Id
                    };

                    pin.Clicked += OnPinClick;
                    

                    pins.Add(pin);
                }

                _dialogService.HideLoading();
                Pins = new ObservableCollection<Pin>(pins);
            }
            else
            {
                _dialogService.HideLoading();
                const string SearchNotFoundAlertTitle = "Product not found";
                const string SearchNotFoundAlertDescription = "Sorry, no product was found";

                await _pageDialogService.DisplayAlertAsync(SearchNotFoundAlertTitle,
                                                       SearchNotFoundAlertDescription,
                                                       Constants.OkAlert);
            }
            
        }

        private async void OnPinClick(object sender, EventArgs e)
        {


            Pin pin = (Pin)sender;
            var parameter = new NavigationParameters();
            parameter.Add("pharmacyId", pin.Tag.ToString());

            Store.CurrentStoreId = int.Parse(pin.Tag.ToString());

            await _navigationService.NavigateAsync($"{Constants.StorePage}", parameter);
        }

        private async Task OnLogout()
        {
            await _navigationService.NavigateAsync($"/{Constants.LogsPage}");
        }


        async Task GetDataDirectionsAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                
                await _pageDialogService.DisplayAlertAsync(NoInternetConnectionAlertTitle, 
                                                       NoInternetConnectionAlertDescription,
                                                       Constants.OkAlert);
                return;
            }

            GoogleDirection directions = await _googleMapsService.GetDirectionAsync(OriginLatitude, OriginLongitude, DestinationLatitude, DestinationLongitude);

            if (directions?.Routes != null && directions.Routes.Count > 0)
            {
                var positions = (Enumerable.ToList(PolylineHelper.Decode(directions.Routes.First().OverviewPolyline.Points)));
            }
            else 
                await _pageDialogService.DisplayAlertAsync(NoRouteAlertTitle, NoRouteAlertDescription, Constants.OkAlert);
         
        }


    }
}
