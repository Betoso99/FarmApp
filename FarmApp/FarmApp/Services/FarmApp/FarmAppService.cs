using FarmApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Services
{
    public class FarmAppService : IFarmAppService
    {
        private const string ApiBaseAddress = "https://azurewebsites.farmAppApi.net";
        
        public async Task<IList<Product>> SearchProductsAsync(string nameInputSearch)
        {
            var farmAppApi = RestService.For<IFarmAppAPI>(ApiBaseAddress);

            var response = await farmAppApi.SearchProducts(nameInputSearch);

            if (response.IsSuccessStatusCode)
            {
                List<Product> products = (List<Product>)response.Content;

                return products;
            }

            return null;
        }
    }
}
