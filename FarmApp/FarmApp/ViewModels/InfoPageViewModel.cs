using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.ViewModels
{
    public class InfoPageViewModel : ViewModelBase
    {
        public INavigationService _navigationService { get; set; }

        public InfoPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Information";
            _navigationService = navigationService;
        }
    }
}
