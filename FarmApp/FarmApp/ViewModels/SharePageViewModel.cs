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

namespace FarmApp.ViewModels
{

    public class SharePageViewModel : ViewModelBase
    {

        #region Services
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _dialogService;
        #endregion

        public DelegateCommand CopyCommand { get; set; }

        #region Constants
        private const string SharePageTitle = "Share";
        private const string SuccessLinkHeader = "Done";
        private const string SuccessLinkDescription = "Your Link has been succesfully copied";
        #endregion

        public string Link { get; set; }

        public SharePageViewModel(INavigationService navigationService, IPageDialogService dialogService) :
            base(navigationService)
        {
            Title = SharePageTitle;
            _dialogService = dialogService;
            _navigationService = navigationService;
            Link = GetLink();

            CopyCommand = new DelegateCommand(async () => await Copy());
        }

        async Task Copy()
        {
            await Clipboard.SetTextAsync(Link);
            await _dialogService.DisplayAlertAsync(SuccessLinkHeader, SuccessLinkDescription, Constants.OkAlert);
        }

        public string GetLink()
        {
            // TODO: Create logic to get actual link location from google maps or some other service

            Link = "https://goo.gl/maps/qwHQ4w9StkBSbvpQ6";

            return Link;
        }
    }

}
