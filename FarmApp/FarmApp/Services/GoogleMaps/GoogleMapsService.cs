using FarmApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Services
{
    public class GoogleMapsService : IGoogleMapsService
    {
        private const string ApiBaseAddress = "https://maps.googleapis.com/maps/";
        public async Task<GoogleDirection> GetDirectionAsync(string originLatitude, string originLongitude, string destinationLatitude, string destinationLongitude)
        {
            GoogleDirection googleDirection = new GoogleDirection();
            var googleMapsApi = RestService.For<IGoogleMapsAPI>(ApiBaseAddress);
            var response = await googleMapsApi.GetDirections(originLatitude, originLongitude, destinationLatitude, destinationLongitude, Constants.GoogleMapsApiKey);
            if (response.IsSuccessStatusCode)
            {
                googleDirection = response.Content;
            }
            return googleDirection;
        }
    }
}
