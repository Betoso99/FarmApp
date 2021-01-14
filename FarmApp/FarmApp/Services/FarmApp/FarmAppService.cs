using FarmApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace FarmApp.Services
{
    public class FarmAppService : IFarmAppService
    {
        private const string ApiBaseAddress = "https://farmappapi.azurewebsites.net/";

        private IFarmAppAPI farmAppApi = RestService.For<IFarmAppAPI>(ApiBaseAddress);

        #region Products

        public async Task<IList<Product>> GetAllProductsAsync()
        {
            var response = await farmAppApi.GetAllProducts();

            if (response.IsSuccessStatusCode)
            {
                List<Product> products = (List<Product>)response.Content;

                return products;
            }

            return null;

        }

        public async Task<IList<Product>> SearchProductsAsync(string nameInputSearch)
        {
            var response = await farmAppApi.SearchProducts(nameInputSearch);

            if (response.IsSuccessStatusCode)
            {
                List<Product> products = (List<Product>)response.Content;

                return products;
            }

            return null;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var response = await farmAppApi.GetProductById(productId);

            if (response.IsSuccessStatusCode)
            {
                Product product = response.Content;

                return product;
            }

            return null;
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
            var response = await farmAppApi.GetProductByName(productName);

            if (response.IsSuccessStatusCode)
            {
                Product product = response.Content;

                return product;
            }

            return null;
        }

        public async Task<IList<Pharmacy>> GetProductPharmaciesAsync(int productId)
        {
            var response = await farmAppApi.GetProductPharmacies(productId);

            if (response.IsSuccessStatusCode)
            {
                List<Pharmacy> pharmacies = (List<Pharmacy>)response.Content;

                return pharmacies;
            }

            return null;
        }

        #endregion

        #region Pharmacies

        public async Task<IList<Pharmacy>> GetAllPharmaciesAsync()
        {
            var response = await farmAppApi.GetAllPharmacies();

            if (response.IsSuccessStatusCode)
            {
                List<Pharmacy> pharmacies = (List<Pharmacy>)response.Content;

                return pharmacies;
            }

            return null;
        }

        public async Task<Pharmacy> GetPharmacyAsync(int pharmacyId)
        {
            var response = await farmAppApi.GetPharmacy(pharmacyId);

            if (response.IsSuccessStatusCode)
            {
                Pharmacy pharmacy = response.Content;

                return pharmacy;
            }

            return null;
        }

        public async Task<IList<ProductPharmacy>> GetPharmacyProductsAsync(int pharmacyId)
        {
            var response = await farmAppApi.GetPharmacyProducts(pharmacyId);

            if (response.IsSuccessStatusCode)
            {
                List<ProductPharmacy> pharmacyProducts = (List<ProductPharmacy>)response.Content;

                return pharmacyProducts;
            }

            return null;
        }

        #endregion

        #region Users

        public async Task<IList<User>> GetAllUsersAsync()
        {
            var response = await farmAppApi.GetAllUsers();

            if (response.IsSuccessStatusCode)
            {
                List<User> users = (List<User>)response.Content;

                return users;
            }

            return null;
        }

        public async Task<UserPerson> GetUserAsync(int userId)
        {
            var response = await farmAppApi.GetUser(userId);

            if (response.IsSuccessStatusCode)
            {
                UserPerson user = response.Content;

                return user;
            }

            return null;
        }

        public async Task<User> LoginUserAsync(User user)
        {
            var response = await farmAppApi.LoginUser(user);

            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }

        public async Task<UserPerson> RegisterUserAsync(UserPerson userPerson)
        {
            var response = await farmAppApi.RegisterUser(userPerson);

            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }
        #endregion

        #region Reviews

        public async Task<IList<Review>> GetAllReviewsAsync()
        {
            var response = await farmAppApi.GetAllReviews();

            if (response.IsSuccessStatusCode)
            {
                List<Review> reviews = (List<Review>)response.Content;

                return reviews;
            }

            return null;
        }

        public async Task<Review> GetReviewAsync(int reviewId)
        {
            var response = await farmAppApi.GetReview(reviewId);

            if (response.IsSuccessStatusCode)
            {
                Review review = response.Content;

                return review;
            }

            return null;
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            var response = await farmAppApi.CreateReview(review);

            if (response.IsSuccessStatusCode)
            {
                return response.Content;
            }

            return null;
        }
        #endregion
    }
}
