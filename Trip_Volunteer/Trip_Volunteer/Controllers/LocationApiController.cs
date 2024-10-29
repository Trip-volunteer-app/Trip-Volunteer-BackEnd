
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Data;
using System.Threading.Tasks;
using Trip_Volunteer.Core.Service;
using System.Net;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Location_ApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILocationService _locationService;

        public Location_ApiController(HttpClient httpClient, ILocationService locationService)
        {
            _httpClient = httpClient;
            _locationService = locationService;
        }

        [HttpGet("get-location-info")]
        public async Task<IActionResult> GetLocationInfo(double latitude, double longitude)
        {
            var apiKey = "AIzaSyDEGmmofoNnuXXtkx6CxIIMgzk1Tkq5kKk";
            var requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}&key={apiKey}";

            var response = await _httpClient.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Error retrieving location information.");
            }

            var content = await response.Content.ReadAsStringAsync();
            return Ok(content); // You can deserialize the JSON and return specific information if needed
        }

        [HttpGet("get-geocode-info")]
        public async Task<IActionResult> GetGeocodeInfo(string Address)
        {
            var apiKey = "AIzaSyDEGmmofoNnuXXtkx6CxIIMgzk1Tkq5kKk"; // Use your own API key
            var requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(Address)}&key={apiKey}";

            var response1 = await _httpClient.GetAsync(requestUrl);
            if (!response1.IsSuccessStatusCode)
            {
                return BadRequest("Error retrieving geocode information.");
            }


            var content = await response1.Content.ReadAsStringAsync();
            Console.WriteLine($"444444444444444444444444444444444444444444444444444{content}");
            var jsonResponse = JObject.Parse(content); // Parse the response into a JObject


            // Check the status
            if (jsonResponse["status"].ToString() != "OK" || jsonResponse["results"].Count() == 0)
            {
                return BadRequest("No results found for the specified address.");
            }


            // Extract latitude and longitude
            var locationInfo = new
            {
                Latitude = (decimal)jsonResponse["results"][0]["geometry"]["location"]["lat"],
                Longitude = (decimal)jsonResponse["results"][0]["geometry"]["location"]["lng"],
                Address = (string)jsonResponse["results"][0]["formatted_address"]
            };

            return Ok(locationInfo);
        }
    }
}