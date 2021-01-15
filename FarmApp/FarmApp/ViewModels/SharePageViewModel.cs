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

        #region Constants
        private const string SharePageTitle = "Share";
        private const string SuccessLinkHeader = "Done";
        private const string SuccessLinkDescription = "Your Link has been succesfully copied";
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
        }

        async Task Copy()
        {
            Link = await GetLink();
            await Clipboard.SetTextAsync(Link);
            await _dialogService.DisplayAlertAsync(SuccessLinkHeader, SuccessLinkDescription, Constants.OkAlert);
        }

        public async Task<string> GetLink()
        {
            var pharmacy = await _farmAppService.GetPharmacyAsync(PharmacyId);

            return $"https://www.google.com/maps/search/?api=1&query={pharmacy.Longitude},{pharmacy.Latitude}";
        }
    }

}
