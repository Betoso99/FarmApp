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

		public StorePageViewModel(INavigationService navigationService) :
			base(navigationService)
		{
			Title = "Store";
			_navigationService = navigationService;
		}

	}
}
