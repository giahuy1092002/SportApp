using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Services
{
    public class DistanceService
    {
        private readonly HttpClient _httpClient;
        public DistanceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<DistanceObject?> GetDistance(double? origin_lat, double? origin_lng, double? dst_lat,double? dst_lng)
        {
            try
            {
                var distance = new DistanceObject();
                var apiKey = "dZJJgWL3VruzjWKhBaondGQogkOgZxkWlLczq48y";
                var url = $"https://rsapi.goong.io/DistanceMatrix?origins={origin_lat},{origin_lng}&destinations={dst_lat},{dst_lng}&vehicle=car&api_key={apiKey}";
                var response = await _httpClient.GetStringAsync(url);
                var json = JObject.Parse(response);
                if (json["rows"]?[0]?["elements"]?[0]?["status"]?.ToString() == "OK")
                {
                    var firstResult = json["rows"]?.FirstOrDefault();
                    if (firstResult != null)
                    {
                        var dis = json["rows"]?[0]?["elements"]?[0]?["distance"]?["text"];
                        var du = json["rows"]?[0]?["elements"]?[0]?["duration"]?["text"];
                        distance.Distance = dis.ToString();
                        distance.Duration = du.ToString();
                    }
                    return distance;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
    public class DistanceObject
    {
        public string Distance { get; set; }
        public string Duration { get; set; }
    }
}
