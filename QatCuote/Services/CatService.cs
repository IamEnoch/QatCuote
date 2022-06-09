using QatCuote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace QatCuote.Services
{
    public class CatService
    {
        HttpClient httpClient;

        public CatService()
        {
            httpClient = new HttpClient();
        }

        CatFact CatFact = new();

        public async Task<CatFact> GetFactAsync()
        {
            string url = "https://catfact.ninja/fact";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var check = await response.Content.ReadAsStringAsync();
                CatFact = await response.Content.ReadFromJsonAsync<CatFact>();
                
            }
            return CatFact;

        }

    }
}
