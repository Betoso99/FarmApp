using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;
using Prism.Services;
using FarmApp.Services;
using FarmApp.Models;


namespace FarmApp.ViewModels
{

    public class SharePageViewModel : ViewModelBase
    {

        #region Services
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        private readonly IFarmAppService _farmAppService;
        #endregion

        public DelegateCommand CopyCommand { get; set; }
        public DelegateCommand OpenMapCommand { get; set; }

        #region Constants
        private const string SharePageTitle = "Share";
        private const string SuccessLinkHeader = "Done";
        private const string SuccessLinkDescription = "Your Link has been succesfully copied";
        private const string OpenMapErrorHeader = "No map app found";
        private const string OpenMapErrorDescription = "You don't have a map installed";
       
        #endregion

        public string Link { get; set; }
        private int PharmacyId { get; set; }

        public SharePageViewModel(INavigationService navigationService, IPageDialogService dialogService, IFarmAppService farmAppService) :
            base(navigationService)
        {
            Title = SharePageTitle;
            _dialogService = dialogService;
            _navigationService = navigationService;
            _farmAppService = farmAppService;
            PharmacyId = Store.CurrentStoreId;

            CopyCommand = new DelegateCommand(async () => await Copy());
            OpenMapCommand = new DelegateCommand(async () => await OpenMap());
        }

        async Task Copy()
        {
            Link = await GetLink();
            await Clipboard.SetTextAsync(Link);
            await _dialogService.DisplayAlertAsync(SuccessLinkHeader, SuccessLinkDescription, Constants.OkAlert);
        }

        public async Task<string> GetLink()
        {
            Pharmacy pharmacy = await _farmAppService.GetPharmacyAsync(PharmacyId);
            return $"https://www.google.com/maps/search/?api=1&query={pharmacy.Longitude},{pharmacy.Latitude}";
        }
        
        async Task OpenMap()
        {
            Pharmacy pharmacy = await _farmAppService.GetPharmacyAsync(PharmacyId);
            var location = new Location(Decimal.ToDouble(pharmacy.Longitude), Decimal.ToDouble(pharmacy.Latitude));
            //var options = new MapLaunchOptions { NavigationMode = Xamarin.Essentials.NavigationMode.Driving };
            
            try
            {
                await Map.OpenAsync(location);
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlertAsync(OpenMapErrorHeader, OpenMapErrorDescription, Constants.OkAlert);
            }
        }

    }

}
