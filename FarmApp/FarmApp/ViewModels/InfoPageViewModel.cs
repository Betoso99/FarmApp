using FarmApp.Models;
using FarmApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.ViewModels
{
    public class InfoPageViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly IFarmAppService _farmAppService;

        // TODO: Need to get this info from a model/DTO (probably called PharmacyInfo) 
        public string Address { get; set; }
        public string Schedule { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }

        private const string InfoPageTitle = "Information";

        private int PharmacyId { get; set; }

        public InfoPageViewModel(INavigationService navigationService, IFarmAppService farmAppService) :
            base(navigationService)
        {
            Title = InfoPageTitle;
            _navigationService = navigationService;
            _farmAppService = farmAppService;
            PharmacyId = Store.CurrentStoreId;

            GetInfo();
        }

		private async void GetInfo()
		{
			var pharmacy = await _farmAppService.GetPharmacyAsync(PharmacyId);

			Name = pharmacy.Name;
			Address = pharmacy.Address;
			Schedule = pharmacy.Schedule;
			Phone = pharmacy.PhoneNumber;

			//Name = "Farmacia Carol";
			//Address = "Arroyo Hondp";
			//Schedule = "8:00 - 12:00";
			//Phone = "8096853566";

		}
	}
}
