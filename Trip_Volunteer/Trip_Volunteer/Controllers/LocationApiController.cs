
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

        [HttpPost("get-geocode-info")]
        public async Task<IActionResult> GetGeocodeInfo(string departureAddress, string destinationAddress)
        {
            var apiKey = "AIzaSyDEGmmofoNnuXXtkx6CxIIMgzk1Tkq5kKk"; // Use your own API key
            var requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(departureAddress)}&key={apiKey}";
            var request2Url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(destinationAddress)}&key={apiKey}";

            var response1 = await _httpClient.GetAsync(requestUrl);
            if (!response1.IsSuccessStatusCode)
            {
                return BadRequest("Error retrieving geocode information.");
            }
            var response2 = await _httpClient.GetAsync(request2Url);
            if (!response2.IsSuccessStatusCode)
            {
                return BadRequest("Error retrieving geocode information.");
            }

            var content = await response1.Content.ReadAsStringAsync();
            Console.WriteLine($"444444444444444444444444444444444444444444444444444{content}");
            var jsonResponse = JObject.Parse(content); // Parse the response into a JObject

            var content2 = await response2.Content.ReadAsStringAsync();
            Console.WriteLine($"444444444444444444444444444444444444444444444444444{content}");
            var jsonResponse2 = JObject.Parse(content2); // Parse the response into a JObject

            // Check the status
            if (jsonResponse["status"].ToString() != "OK" || jsonResponse["results"].Count() == 0)
            {
                return BadRequest("No results found for the specified address.");
            }


            // Extract latitude and longitude
            var latitudeDeparture = (decimal)jsonResponse["results"][0]["geometry"]["location"]["lat"];
            var longitudeDeparture = (decimal)jsonResponse["results"][0]["geometry"]["location"]["lng"];
            var latitudeDestination = (decimal)jsonResponse2["results"][0]["geometry"]["location"]["lat"];
            var longitudeDestination = (decimal)jsonResponse2["results"][0]["geometry"]["location"]["lng"];
            // Create a new Location object
            var location = new Location
            {
                Departure_Latitude = latitudeDeparture,
                Departure_Longitude = longitudeDeparture,
                Departure_Location = departureAddress,
                Destination_Location = destinationAddress,
                Destination_Latitude = latitudeDestination,
                Destination_Longitude = longitudeDestination,
            };

            // Use the existing service method to add the location to the database
            try
            {
                _locationService.CREATElocation(location);
            }
            catch (Exception ex)
            {
                // Handle the exception, return a meaningful message
                return StatusCode(StatusCodes.Status500InternalServerError, "Error saving location to the database.");
            }

            return Ok(location); // Return the saved location or other relevant info
        }
    }
}