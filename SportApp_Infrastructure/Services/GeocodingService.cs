using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Services
{
    public class GeocodingService
    {
        private readonly HttpClient _httpClient;

        public GeocodingService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<(double latitude, double longitude)> GetCoordinatesAsync(string address)
        {
            var apiKey = "AIzaSyCTgiC01yqLlRE-bsZ1Ssk3QK7BCFXJX_U";
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(address)}&key={apiKey}";

            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            if (json["status"].ToString() == "OK")
            {
                var location = json["results"][0]["geometry"]["location"];
                double latitude = location["lat"].Value<double>();
                double longitude = location["lng"].Value<double>();
                return (latitude, longitude);
            }

            throw new Exception("Không tìm thấy địa chỉ.");
        }
    }
}
