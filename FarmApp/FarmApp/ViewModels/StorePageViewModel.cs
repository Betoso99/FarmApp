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
		public DelegateCommand Nav { get; set; }

		public StorePageViewModel(INavigationService navigationService) :
			base(navigationService)
		{
			Title = "Store Page";
			_navigationService = navigationService;
			Nav = new DelegateCommand(NavigationExecute);
		}

		async void NavigationExecute()
		{
			await _navigationService.GoBackAsync();
		}
	}
}
