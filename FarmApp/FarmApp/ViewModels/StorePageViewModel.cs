using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.ViewModels
{
    public class StorePageViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;


        private const string StorePageTitle = "Store";
        private int PharmacyId { get; set; }

        public StorePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
            base(navigationService)
        {
            Title = StorePageTitle;

            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var pharmacyid = int.Parse(parameters["pharmacyId"] as string);
            Store.CurrentStoreId = pharmacyid;
            
        }

    }
}
