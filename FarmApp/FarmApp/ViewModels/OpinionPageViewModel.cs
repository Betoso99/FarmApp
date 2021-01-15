using FarmApp.Models;
using FarmApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FarmApp.ViewModels
{
    public class OpinionPageViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly IFarmAppService _farmAppService;

        public ObservableCollection<Review> Opinions { get; set; }

        private const string OpinionPageTitle = "Opinions";
        private int PharmacyId { get; set; }

        public OpinionPageViewModel(INavigationService navigationService, IFarmAppService farmAppService) :
            base(navigationService)
        {
            Title = OpinionPageTitle;
            _navigationService = navigationService;
            _farmAppService = farmAppService;
            PharmacyId = Store.CurrentStoreId;
            GetInfo();
        }

		private async void GetInfo()
		{
			var pharmacy = await _farmAppService.GetAllReviewsAsync();
			Opinions = new ObservableCollection<Review>(pharmacy);
		}
	}
}
