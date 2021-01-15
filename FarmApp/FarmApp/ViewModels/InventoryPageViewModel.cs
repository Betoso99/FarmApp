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

		public int PharmacyId { get; set; }

		public InventoryPageViewModel(INavigationService navigationService, IFarmAppService farmAppService) :
			base(navigationService)
		{
			Title = "Inventory";
			_navigationService = navigationService;
			_farmAppService = farmAppService;
			//PharmacyId = pharmacyId;


			// TODO: Unfinished logic

			//var prods = Task.Run(async () => await GetPharmacyProducts()).ConfigureAwait(false).GetAwaiter();

   //         foreach (var prod in prods.GetResult())
   //         {
			//	PharmacyProducts.Add(prod);
			//}
		}

		//private async Task<List<ProductPharmacy>> GetPharmacyProducts()
  //      {
		//	var products = await _farmAppService.GetPharmacyProductsAsync(PharmacyId);

		//	return products;
  //      }
	}
}
