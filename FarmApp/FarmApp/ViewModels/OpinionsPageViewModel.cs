using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.ViewModels
{
    public class OpinionsPageViewModel : ViewModelBase
    {
        public INavigationService _navigationService { get; set; }

        public OpinionsPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = "Opinions";
            _navigationService = navigationService;
        }
    }
}
