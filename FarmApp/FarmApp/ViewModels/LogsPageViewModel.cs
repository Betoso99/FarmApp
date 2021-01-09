using FarmApp.Models;
using FarmApp.Views;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FarmApp.ViewModels
{
	public class LogsPageViewModel : ViewModelBase
	{
		public INavigationService _navigationService { get; set; }
		public IPageDialogService _pageDialogService { get; set; }
		public User User { get; set; }

		public ICommand LogInCommand { get; set; }
		public ICommand SingUpCommand { get; set; }

		public LogsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
			base(navigationService)
		{
			Title = "Information";
			_navigationService = navigationService;
			_pageDialogService = pageDialogService;
			

			User = new User();
			LogInCommand = new Command(async () => await OnLogin());
			SingUpCommand = new Command(async () => await OnSingUp() );
		}

        public async Task OnLogin()
        {
			if (string.IsNullOrEmpty(User.Name) | string.IsNullOrEmpty(User.Pass))
			{
				await _pageDialogService.DisplayAlertAsync("Error", "Something is missing", "Ok");
			}
			else
			{
				await _navigationService.NavigateAsync($"/{Constants.NavigationPage}/{Constants.HomePage}");
				await _pageDialogService.DisplayAlertAsync("Welcome", $"Welcome again {User.Name}", "Ok");
			}
		}

		public async Task OnSingUp()
        {
			if (string.IsNullOrEmpty(User.Name) |
				string.IsNullOrEmpty(User.Email) |
				string.IsNullOrEmpty(User.Pass1) |
				string.IsNullOrEmpty(User.Pass2))
			{
				await App.Current.MainPage.DisplayAlert("Error", "Something is missing", "Ok");
			}
			else if (User.Pass1 != User.Pass2)
			{
				await App.Current.MainPage.DisplayAlert("Error", "The Passwords are not the same", "Ok");
			}
			else
			{
				await App.Current.MainPage.Navigation.PushModalAsync(new HomePage());
				await App.Current.MainPage.DisplayAlert("Welcome", $"Welcome again {User.Name}", "Ok");
			}
		}
	}
}
