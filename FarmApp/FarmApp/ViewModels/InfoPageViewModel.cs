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
            GetInfo();
        }

		private void GetInfo()
		{
            Direction = "Av Mexico 64, Santo Domingo 10107";
            Schedule = "8:00 - 18:00";
            Phone = "+1 809-565-5112";
            Web = "https://www.facebook.com/farmaciathasulij";
		}
	}
}
