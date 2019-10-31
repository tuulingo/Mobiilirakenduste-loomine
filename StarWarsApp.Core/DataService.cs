using Newtonsoft.Json;
using StarWarsApp.Core.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsApp.Core
{
    public class DataService
    {
        public static async Task<People> GetStarWarsPeople(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(queryString);

            People data = null;
            if (response != null)
            {
                data = JsonConvert.DeserializeObject<People>(response);
            }
            return data;
        }
    }
}
