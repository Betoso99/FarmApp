using FarmApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Services
{
    [Headers("Content-Type: application/json")]
    public interface IGoogleMapsAPIService
    {
        [Get("/api/directions/json?mode=driving&transit_routing_preference=less_driving&origin={originLatitude},{originLongitude}&destination={destinationLatitude},{destinationLongitude}&key={googleMapsKey}")]
        Task<GoogleDirection> GetDirections(string originLatitude, string originLongitude, string destinationLatitude, string destinationLongitude, string googleMapsKey);
    }
}
