using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Services
{
    public class DirectionService
    {
        private readonly HttpClient _httpClient;

        public DirectionService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<double> GetDistanceAsync(string origin, string destination)
        {
            var apiKey = "AIzaSyDNzTzyji85cxA7iLmIoCMP982b5H89JMQ"; // Thay thế bằng API Key của bạn
            var url = $"https://maps.googleapis.com/maps/api/directions/json?origin={Uri.EscapeDataString(origin)}&destination={Uri.EscapeDataString(destination)}&key={apiKey}";

            var response = await _httpClient.GetStringAsync(url);
            var json = JObject.Parse(response);

            if (json["status"].ToString() == "OK")
            {
                var distanceText = json["routes"][0]["legs"][0]["distance"]["value"].Value<double>(); // Đơn vị là mét
                return distanceText; // Khoảng cách trả về theo mét
            }

            throw new Exception("Không thể tính khoảng cách.");
        }
    }
}
