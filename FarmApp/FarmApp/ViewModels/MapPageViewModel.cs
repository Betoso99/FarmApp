using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.ViewModels
{
	public class MapPageViewModel : ViewModelBase
	{
		public INavigationService _navigationService { get; set; }
		public DelegateCommand Nav { get; set; }

		public MapPageViewModel(INavigationService navigationService) :
			base(navigationService)
		{
			Title = "Map Page";
			_navigationService = navigationService;
			Nav = new DelegateCommand(NavigationExecute);
		}

		async void NavigationExecute()
		{
			await _navigationService.NavigateAsync("SearchedPage");
		}
	}
}
