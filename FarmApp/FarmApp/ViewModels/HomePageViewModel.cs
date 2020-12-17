using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace FarmApp.ViewModels
{
	public class HomePageViewModel : ViewModelBase
	{
		public INavigationService _navigationService { get; set; }
		public DelegateCommand Nav { get; set; }

		public HomePageViewModel(INavigationService navigationService) :
			base(navigationService)
		{
			Title = "Home Page";
			_navigationService = navigationService;
			Nav = new DelegateCommand(NavigationExecute);
		}		

		async void NavigationExecute()
		{
			await _navigationService.NavigateAsync("SearchedPage");
		}
	}
}
