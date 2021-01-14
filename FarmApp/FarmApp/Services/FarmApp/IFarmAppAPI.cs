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

        #region Products

        [Get("/api/products")]
        Task<ApiResponse<List<Product>>> GetAllProducts();

        [Get("/api/products/search?name={nameInputSearch}")]
        Task<ApiResponse<List<Product>>> SearchProducts(string nameInputSearch);

        [Get("/api/products/{productId}")]
        Task<ApiResponse<Product>> GetProductById(int productId);

        [Get("/api/products/{productName}")]
        Task<ApiResponse<Product>> GetProductByName(string productName);

        [Get("/api/products/{productId}/pharmacies")]
        Task<ApiResponse<IList<Pharmacy>>> GetProductPharmacies(int productId);
        #endregion

        #region Pharmacies
        [Get("/api/pharmacies")]
        Task<ApiResponse<IList<Pharmacy>>> GetAllPharmacies();

        [Get("/api/pharmacies/{pharmacyId}")]
        Task<ApiResponse<Pharmacy>> GetPharmacy(int pharmacyId);

        [Get("/api/pharmacies/{pharmacyId}/products")]
        Task<ApiResponse<IList<ProductPharmacy>>> GetPharmacyProducts(int pharmacyId);
        #endregion

        #region Users
        [Get("/api/users")]
        Task<ApiResponse<IList<User>>> GetAllUsers();

        [Get("/api/users/{userId}")]
        Task<ApiResponse<UserPerson>> GetUser(int userId);

        [Post("/api/users/register")]
        Task<ApiResponse<UserPerson>> RegisterUser([Body] UserPerson userPerson);

        [Post("/api/users/login")]
        Task<ApiResponse<User>> LoginUser([Body] User user);
        #endregion

        #region Reviews

        [Get("/api/reviews")]
        Task<ApiResponse<IList<Review>>> GetAllReviews();

        [Get("/api/reviews/{reviewId}")]
        Task<ApiResponse<Review>> GetReview(int reviewId);

        [Post("/api/reviews")]
        Task<ApiResponse<Review>> CreateReview(Review review);
        #endregion
    }

}
