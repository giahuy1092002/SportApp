using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure.Services
{
    public class GeoCodeService
    {
        private readonly HttpClient _httpClient;
        public GeoCodeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<GeoObject> ConvertAddress(string address)
        {
            try
            {
                var geo = new GeoObject();
                string encodeAddress = address.Replace(" ", "%20").Replace(",", "%2C");
                var apiKey = "dZJJgWL3VruzjWKhBaondGQogkOgZxkWlLczq48y";
                var url = $"https://rsapi.goong.io/geocode?address={encodeAddress}&api_key={apiKey}";
                //var url = "https://rsapi.goong.io/geocode?address=91%20Trung%20K%C3%ADnh%2C%20Trung%20Ho%C3%A0%2C%20C%E1%BA%A7u%20Gi%E1%BA%A5y%2C%20H%C3%A0%20N%E1%BB%99i&api_key=dZJJgWL3VruzjWKhBaondGQogkOgZxkWlLczq48y";

                var response = await _httpClient.GetStringAsync(url);
                var json = JObject.Parse(response);
                if (json?["status"]?.ToString() == "OK")
                {
                    // Lấy phần tử đầu tiên trong danh sách kết quả
                    var firstResult = json["results"]?.FirstOrDefault();
                    if (firstResult != null)
                    {
                        // Lấy tọa độ lat và lng
                        var lat = (double)firstResult["geometry"]["location"]["lat"];
                        var lng = (double)firstResult["geometry"]["location"]["lng"];
                        geo.Longitude = lng;
                        geo.Latitude = lat;
                        return geo;
                    }
                }
                return geo;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            } 
            
        }
    }
    public class GeoObject
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
