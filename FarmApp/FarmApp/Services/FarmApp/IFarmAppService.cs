using FarmApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Services
{
    public interface IFarmAppService
    {
        Task<IList<Product>> SearchProductsAsync(string nameInputSearch);
    }
}
