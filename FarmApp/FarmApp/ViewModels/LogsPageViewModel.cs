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
using FarmApp.Services;

namespace FarmApp.ViewModels
{
    public class LogsPageViewModel : ViewModelBase
    {

        #region Services

        public INavigationService _navigationService { get; set; }
        public IPageDialogService _pageDialogService { get; set; }
        private IFarmAppService _farmAppApiService;
        #endregion

        #region Commands

        public ICommand LogInCommand { get; set; }
        public ICommand SingUpCommand { get; set; }
        #endregion

        #region Constants

        private const string LogsPageTitle = "Login/Sign Up";

        private const string InvalidFieldsAlertTitle = "Invalid fields";
        private const string InvalidFieldsAlertDescription = "Fields cannot be empty";

        private const string InvalidPasswordAlertTitle = "Invalid password";
        private const string InvalidPasswordAlertDescription = "Passwords cannot be the same";

        private const string SuccessLoginAlertTitle = "Welcome Back";
        private const string SuccessLoginAlertDescription = "Welcome again";

        private const string SuccessSignupAlertTitle = "Welcome";
        private const string SuccessSignupAlertDescription = "Welcome to FarmApp";
//<<<<<<< dev/ariel

        private const string FailSignupAlertTitle = "Sign Up failed";
        private const string FailSignupAlertDescription = "Seems like this email already exists from another acount";

        private const string InvalidLoginAlertTitle = "Login Error";
        private const string InvalidLoginAlertDescription = "Invalid Username / Password";

//=======
        private TypePicker selectedGender;
        private CustomDatePicker selectedDate;
//>>>>>>> main
        #endregion

        #region Models

        public User User { get; set; }
        public UserPerson UserPerson { get; set; }
        public string ConfirmPassword { get; set; }
        public List<TypePicker> Genders { get; set; }
        public TypePicker SelectedGender
        {
            get { return selectedGender; }
            set
            {
                selectedGender = value;
                if (selectedGender != null)
                {
                    Gender();
                }
            }
        }
        public CustomDatePicker SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                if (selectedDate != null)
                {
                    Date();
                }
            }
        }
        #endregion

        public string LogsBackgroundImage => "Wallpaper.jpg";
        public string LoginTitle => "Login";
        public string LoginIconImage => "LogIn.png";
        public string SignUpTitle => "Sign Up";
        public string SignUpIconImage => "SignUp.png";


        

        public LogsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, 
                                IFarmAppService farmAppService) :
            base(navigationService)
        {
            Title = LogsPageTitle;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _farmAppApiService = farmAppService;

            PickerGender();
            User = new User();
            UserPerson = new UserPerson();
            LogInCommand = new Command(async () => await OnLogin());
            SingUpCommand = new Command(async () => await OnSingUp());
        }

        public async Task OnLogin()
        {
            if (string.IsNullOrEmpty(User.UserName) | string.IsNullOrEmpty(User.Password))
            {
                await _pageDialogService.DisplayAlertAsync(
                    InvalidFieldsAlertTitle, InvalidFieldsAlertDescription, Constants.OkAlert
                );
            }
            else
            {
                string LoginAlertDescription = $"{SuccessLoginAlertDescription}, {User.UserName}";
               
                // Agregando usuario a la BD, si devuelve null es porque hubo un error
                var user = await _farmAppApiService.LoginUserAsync(User);
                
                if(user != null)
                {
                    await _navigationService.NavigateAsync($"/{Constants.NavigationPage}/{Constants.HomePage}");
                    
                    await _pageDialogService.DisplayAlertAsync(
                        SuccessLoginAlertTitle, LoginAlertDescription, Constants.OkAlert
                    );
                }
                else
                {
                    await _pageDialogService.DisplayAlertAsync(
                        InvalidLoginAlertTitle, InvalidLoginAlertDescription, Constants.OkAlert
                    );
                }
                    
             
            }
        }

        public void PickerGender()
        {
            Genders = new List<TypePicker>() { };
            Genders.Add(new TypePicker { Gender = "Female" });
            Genders.Add(new TypePicker { Gender = "Male" });
        }

        public void Gender()
        {
            UserPerson.Gender = SelectedGender.Gender[0].ToString();
        }

        public void Date()
        {
            UserPerson.BirthDate = SelectedDate.Date;
        }

        public async Task OnSingUp()
        {
            if (string.IsNullOrEmpty(UserPerson.FirstName) | string.IsNullOrEmpty(UserPerson.LastName) |
                string.IsNullOrEmpty(UserPerson.Password) | string.IsNullOrEmpty(ConfirmPassword))
            {

                await _pageDialogService.DisplayAlertAsync(
                    InvalidFieldsAlertTitle, InvalidFieldsAlertDescription, Constants.OkAlert
                );
            }
            else if (UserPerson.Password != ConfirmPassword)
            {
                await _pageDialogService.DisplayAlertAsync(
                    InvalidPasswordAlertTitle, InvalidPasswordAlertDescription, Constants.OkAlert
                );
            }
            else
            {
                string SignUpAlertDescription = $"{SuccessSignupAlertDescription}, {UserPerson.FirstName}";

                var person = await _farmAppApiService.RegisterUserAsync(UserPerson);

                if (person != null)
                {
                    await _navigationService.NavigateAsync($"/{Constants.NavigationPage}/{Constants.HomePage}");
                    await _pageDialogService.DisplayAlertAsync(
                        SuccessSignupAlertTitle, SignUpAlertDescription, Constants.OkAlert
                     );
                }
                else
                    await _pageDialogService.DisplayAlertAsync(
                        FailSignupAlertTitle, FailSignupAlertDescription, Constants.OkAlert
                     );

            }
        }
    }
}
