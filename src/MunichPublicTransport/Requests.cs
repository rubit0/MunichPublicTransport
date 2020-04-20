using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MunichPublicTransport.Dtos;
using MunichPublicTransport.Misc;
using MunichPublicTransport.Models;

namespace MunichPublicTransport
{
    public static class Requests
    {
        /// <summary>
        /// Find locations by name or location id.
        /// </summary>
        /// <param name="id">Search term or location id</param>
        /// <returns>A collection of locations that match the search.</returns>
        public static async Task<List<Location>> FindLocation(string search)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-MVG-Authorization-Key", Constants.ApiKey);
                var response = await client.GetAsync($"{Constants.BaseUrl}location/query?q={search}");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                
                var body = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<StationsRequestResult>(body);
                return result.Locations;
            }
        }
        
        /// <summary>
        /// Get nearby stations by lat and long.
        /// The API gives no feature to specify a radius.
        /// </summary>
        /// <returns>A collection of nearby locations.</returns>
        public static async Task<List<Location>> GetNearbyLocations(string latitude, string longitude)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-MVG-Authorization-Key", Constants.ApiKey);
                var response = await client.GetAsync($"{Constants.BaseUrl}location/nearby?latitude={latitude}&longitude={longitude}");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                
                var body = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<StationsRequestResult>(body);
                return result.Locations;
            }
        }

        /// <summary>
        /// Get departures for a give location id.
        /// The time range for the next departures can't be specified.
        /// </summary>
        /// <param name="id">Id of the desired location.</param>
        /// <returns>A collection fo departures and associated serving lines.</returns>
        public static async Task<Departures> GetDeparturesForLocation(string id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-MVG-Authorization-Key", Constants.ApiKey);
                var response = await client.GetAsync($"{Constants.BaseUrl}departure/{id}?footway=0");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                
                var body = await response.Content.ReadAsStringAsync();
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<DepartureRequestResult>(body);
                return new Departures{ NextDepartures = result.Departures, ServingLines = result.ServingLines };
            }
        }
    }
}