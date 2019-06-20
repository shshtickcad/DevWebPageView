using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DevExtremeAspNetCoreApp1.Config
{
    public static class ConfigClient
    {
        public static HttpClient _client { get; set; } 

        public static void InitializeClient()
        {
            _client = new HttpClient();
            //Properties.Settings.Default.Reset();
            _client.BaseAddress = new Uri("http://localhost:7700/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
