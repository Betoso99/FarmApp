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

        private const string LogsPageTitle = "Login/Sign Up";

        private const string InvalidFieldsAlertTitle = "Invalid fields";
        private const string InvalidFieldsAlertDescription = "Fields cannot be empty";

        private const string InvalidPasswordAlertTitle = "Invalid password";
        private const string InvalidPasswordAlertDescription = "Passwords cannot be the same";

        private const string SuccessLoginAlertTitle = "Welcome Back";
        private const string SuccessLoginAlertDescription = "Welcome again";

        private const string SuccessSignupAlertTitle = "Welcome";
        private const string SuccessSignupAlertDescription = "Welcome to FarmApp";

        public string LogsBackgroundImage => "Wallpaper.jpg";

        public string LoginTitle => "Login";
        public string LoginIconImage => "LogIn.png";

        public string SignUpTitle => "Sign Up";
        public string SignUpIconImage => "SignUp.png";




        public LogsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
            base(navigationService)
        {
            Title = LogsPageTitle;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;


            User = new User();
            LogInCommand = new Command(async () => await OnLogin());
            SingUpCommand = new Command(async () => await OnSingUp());
        }

        public async Task OnLogin()
        {
            if (string.IsNullOrEmpty(User.Name) | string.IsNullOrEmpty(User.Pass))
            {
                await App.Current.MainPage.DisplayAlert(InvalidFieldsAlertTitle,
                                                        InvalidFieldsAlertDescription,
                                                        Constants.OkAlert);
            }
            else
            {
                string LoginAlertDescription = $"{SuccessLoginAlertDescription}, {User.Name}";

                await _navigationService.NavigateAsync($"/{Constants.NavigationPage}/{Constants.HomePage}");
                await _pageDialogService.DisplayAlertAsync(SuccessLoginAlertTitle,
                                                           LoginAlertDescription,
                                                           Constants.OkAlert);
            }
        }

        public async Task OnSingUp()
        {
            if (string.IsNullOrEmpty(User.Name) | string.IsNullOrEmpty(User.Email) |
                string.IsNullOrEmpty(User.Pass) | string.IsNullOrEmpty(User.Pass2))
            {

                await App.Current.MainPage.DisplayAlert(InvalidFieldsAlertTitle,
                                                        InvalidFieldsAlertDescription,
                                                        Constants.OkAlert);
            }
            else if (User.Pass != User.Pass2)
            {
                await App.Current.MainPage.DisplayAlert(InvalidPasswordAlertTitle,
                                                        InvalidPasswordAlertDescription,
                                                        Constants.OkAlert);
            }
            else
            {
                string SignUpAlertDescription = $"{SuccessSignupAlertDescription}, {User.Name}";

                await App.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                await App.Current.MainPage.DisplayAlert(SuccessSignupAlertTitle,
                                                        SignUpAlertDescription,
                                                        Constants.OkAlert);
            }
        }
    }
}
