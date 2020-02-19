using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FootballMVC.Data.ApiData
{
    public  class Connection
    {
        public void ConnectionToApi(HttpClient Client)
        {
            Client.BaseAddress = new Uri("https://apiv2.apifootball.com");
            Client.DefaultRequestHeaders.Accept.Clear();

            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
