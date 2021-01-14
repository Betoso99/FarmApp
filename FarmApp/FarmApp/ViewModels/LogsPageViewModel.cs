﻿using FarmApp.Models;
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
        private TypePicker selectedGender;
        private CustomDatePicker selectedDate;
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

        public LogsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) :
            base(navigationService)
        {
            Title = LogsPageTitle;
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

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
                await App.Current.MainPage.DisplayAlert(InvalidFieldsAlertTitle,
                                                        InvalidFieldsAlertDescription,
                                                        Constants.OkAlert);
            }
            else
            {
                string LoginAlertDescription = $"{SuccessLoginAlertDescription}, {User.UserName}";

                await _navigationService.NavigateAsync($"/{Constants.NavigationPage}/{Constants.HomePage}");
                await _pageDialogService.DisplayAlertAsync(SuccessLoginAlertTitle,
                                                           LoginAlertDescription,
                                                           Constants.OkAlert);
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

                await App.Current.MainPage.DisplayAlert(InvalidFieldsAlertTitle,
                                                        InvalidFieldsAlertDescription,
                                                        Constants.OkAlert);
            }
            else if (UserPerson.Password != ConfirmPassword)
            {
                await App.Current.MainPage.DisplayAlert(InvalidPasswordAlertTitle,
                                                        InvalidPasswordAlertDescription,
                                                        Constants.OkAlert);
            }
            else
            {
                string SignUpAlertDescription = $"{SuccessSignupAlertDescription}, {UserPerson.FirstName}";

                await App.Current.MainPage.Navigation.PushModalAsync(new HomePage());
                await App.Current.MainPage.DisplayAlert(SuccessSignupAlertTitle,
                                                        SignUpAlertDescription,
                                                        Constants.OkAlert);
            }
        }
    }
}