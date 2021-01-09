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
	public class InventoryPageViewModel : ViewModelBase
	{
		public INavigationService _navigationService { get; set; }
		public ObservableCollection<Products> PharmacyProducts { get; set; }

		public InventoryPageViewModel(INavigationService navigationService) :
			base(navigationService)
		{
			Title = "Inventory";
			_navigationService = navigationService;
		}
	}
}
