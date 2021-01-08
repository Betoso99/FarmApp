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
        public INavigationService _navigationService { get; set; }
        public IPageDialogService _dialogService { get; set; }
        public DelegateCommand CopyCommand { get; set; }
        public string Link { get; set; }

        public SharePageViewModel(INavigationService navigationService, IPageDialogService dialogService) :
            base(navigationService)
        {
            Title = "Share";
            _dialogService = dialogService;
            _navigationService = navigationService;
            Link = GetLink();

            CopyCommand = new DelegateCommand(async () => await Copy());
        }

        async Task Copy()
		{
            await Clipboard.SetTextAsync(Link);
            await _dialogService.DisplayAlertAsync("Done", "Your Link has been succesfully copied", "OK"); ;
        }

        public String GetLink()
        {
            Link = "https://goo.gl/maps/qwHQ4w9StkBSbvpQ6";
            return Link;
        }
    }
}
