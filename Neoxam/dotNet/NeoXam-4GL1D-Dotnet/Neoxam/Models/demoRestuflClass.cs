using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Neoxam.Models
{
    public class demoRestuflClass
    {
        public Task<string> getDep()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Neoxam4GL1D-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/dep/getDep").Result;

            return response.Content.ReadAsStringAsync();
        }
        public string seif()
        {
            return "ok";
        }
    }
}