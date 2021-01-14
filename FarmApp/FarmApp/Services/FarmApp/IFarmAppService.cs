using FarmApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Services
{
    public interface IFarmAppService
    {
        #region Products

        Task<IList<Product>> GetAllProductsAsync();
        Task<IList<Product>> SearchProductsAsync(string nameInputSearch);
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> GetProductByNameAsync(string productName);
        Task<IList<Pharmacy>> GetProductPharmaciesAsync(int productId);
        #endregion

        #region Pharmacies

        Task<IList<Pharmacy>> GetAllPharmaciesAsync();
        Task<Pharmacy> GetPharmacyAsync(int pharmacyId);
        Task<IList<ProductPharmacy>> GetPharmacyProductsAsync(int pharmacyId);
        #endregion

        #region Users

        Task<IList<User>> GetAllUsersAsync();
        Task<UserPerson> GetUserAsync(int userId);
        Task<UserPerson> RegisterUserAsync(UserPerson userPerson);
        Task<User> LoginUserAsync(User user);
        #endregion
    }
}
