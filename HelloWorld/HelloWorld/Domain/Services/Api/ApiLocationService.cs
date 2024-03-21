using HelloWorld.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Domain.Services.Api
{
    public class ApiLocationService : ILocationService
    {
        public async Task<List<Location>> GetLocations()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync("https://raw.githubusercontent.com/howest-gp-mde/cu-maui-campusdetector/master/data/campuses.json");

                return JsonConvert.DeserializeObject<List<Location>>(response);
                 
            }
        }
    }
}
