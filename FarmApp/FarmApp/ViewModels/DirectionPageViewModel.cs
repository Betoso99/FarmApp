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
        public INavigationService _navigationService { get; set; }
        public DirectionPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Directions";
            _navigationService = navigationService;
        }
    }
}
