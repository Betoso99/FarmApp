using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.ViewModels
{
    public class StorePageViewModel : ViewModelBase
    {

        public INavigationService _navigationService { get; set; }

        private const string StorePageTitle = "Store";

        public StorePageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = StorePageTitle;

            _navigationService = navigationService;
        }

    }
}
