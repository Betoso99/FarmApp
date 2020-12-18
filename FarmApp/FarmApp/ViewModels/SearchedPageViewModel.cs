using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmApp.ViewModels
{
	public class SearchedPageViewModel : ViewModelBase
	{
		public INavigationService _navigationService { get; set; }
		public DelegateCommand Nav { get; set; }
		public DelegateCommand Back { get; set; }

		public SearchedPageViewModel(INavigationService navigationService) :
			base(navigationService)
		{
			Title = "Searched Page";
			_navigationService = navigationService;
			Nav = new DelegateCommand(NavigationExecute);
			Back = new DelegateCommand(BackHome);
		}

		async void NavigationExecute()
		{
			await _navigationService.NavigateAsync("StorePage");
		}

		async void BackHome()
		{
			//await _navigationService.NavigateAsync(new Uri("HomePage", System.UriKind.Absolute));
			await _navigationService.GoBackAsync();
		}
	}
}
