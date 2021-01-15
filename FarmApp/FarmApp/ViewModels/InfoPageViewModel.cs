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
        #region Services
        private readonly INavigationService _navigationService;
        private readonly IFarmAppService _farmAppService;

        #endregion

        #region Constants
        private const string InfoPageTitle = "Information";

        #endregion

        public string Address { get; set; }
        public string Schedule { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
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

		}
	}
}
