using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.ViewModels
{
    public class DirectionPageViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;

        private const string InfoPageTitle = "Information";
 
        public DirectionPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = InfoPageTitle;
            _navigationService = navigationService;
        }
    }
}
