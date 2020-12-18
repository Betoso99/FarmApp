using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.ViewModels
{

    public class SharePageViewModel : ViewModelBase
    {
        public INavigationService _navigationService { get; set; }

        public SharePageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Share";
            _navigationService = navigationService;
        }
    }
}
