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
            Link = GetLink();

            CopyCommand = new DelegateCommand(async () => await Copy());
            CopyCommand = new DelegateCommand(async () => await OpenMap());
        }

        async Task Copy()
        {
            await Clipboard.SetTextAsync(Link);
            await _dialogService.DisplayAlertAsync(SuccessLinkHeader, SuccessLinkDescription, Constants.OkAlert);
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

        public string GetLink()
        {
            // TODO: Create logic to get actual link location from google maps or some other service

            Link = "https://goo.gl/maps/qwHQ4w9StkBSbvpQ6";
            return Link;
        }
    }

}
