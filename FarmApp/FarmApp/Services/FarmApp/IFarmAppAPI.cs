using FarmApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Services
{
    [Headers("Content-Type: application/json")]
    public interface IFarmAppAPI
    {
        [Get("api/products/search?name={nameInputSearch}")]
        Task<ApiResponse<IList<Product>>> SearchProducts(string nameInputSearch);
    }

}
