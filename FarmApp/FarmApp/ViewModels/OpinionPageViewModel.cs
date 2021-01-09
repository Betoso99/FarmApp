using FarmApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FarmApp.ViewModels
{
    public class OpinionPageViewModel : ViewModelBase
    {

        private readonly INavigationService _navigationService;

        public ObservableCollection<Opinion> Opinions { get; set; }

        private const string OpinionPageTitle = "Opinions";

        public OpinionPageViewModel(INavigationService navigationService) :
            base(navigationService)
        {
            Title = OpinionPageTitle;
            _navigationService = navigationService;
        }
    }
}
