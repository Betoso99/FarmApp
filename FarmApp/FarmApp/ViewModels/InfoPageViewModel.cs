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
        public string Direction { get; set; }
        public string Schedule { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }

        public InfoPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Information";
            _navigationService = navigationService;
        }
    }
}
