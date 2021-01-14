using FarmApp.Models;
using System.Threading.Tasks;

namespace FarmApp.Services
{
    public interface IGoogleMapsService
    {
        Task<GoogleDirection> GetDirectionAsync(string originLatitude, string originLongitude, string destinationLatitude, string destinationLongitude);
    }
}
