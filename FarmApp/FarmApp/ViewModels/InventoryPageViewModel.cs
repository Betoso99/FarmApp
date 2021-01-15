using FarmApp.Models;
using FarmApp.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.ViewModels
{
	public class InventoryPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly IFarmAppService _farmAppService;
		public ObservableCollection<ProductPharmacy> PharmacyProducts { get; set; }

		private int PharmacyId { get; set; }

		public InventoryPageViewModel(INavigationService navigationService, IFarmAppService farmAppService) :
			base(navigationService)
		{
			Title = "Inventory";
			_navigationService = navigationService;
			_farmAppService = farmAppService;
			PharmacyId = Store.CurrentStoreId;
			//GetPharmacyProducts();
			//PharmacyProducts = new ObservableCollection<ProductPharmacy>((IEnumerable<ProductPharmacy>)inventory);


			// TODO: Unfinished logic

			//var prods = Task.Run(async () => await GetPharmacyProducts()).ConfigureAwait(false).GetAwaiter();

			//         foreach (var prod in prods.GetResult())
			//         {
			//	PharmacyProducts.Add(prod);
			//}
		}

		private async void GetPharmacyProducts()
		{
			var products = await _farmAppService.GetPharmacyProductsAsync(PharmacyId);
			PharmacyProducts = new ObservableCollection<ProductPharmacy>(products);
		}
	}
}
