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

        private readonly INavigationService _navigationService;

        // TODO: Need to get this info from a model/DTO (probably called PharmacyInfo) 
        public string Direction { get; set; }
        public string Schedule { get; set; }
        public string Phone { get; set; }
        public string Web { get; set; }

        private const string InfoPageTitle = "Information";

        public InfoPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = InfoPageTitle;
            _navigationService = navigationService;
        }
    }
}
