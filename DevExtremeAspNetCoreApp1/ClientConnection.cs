using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DevExtremeAspNetCoreApp1
{
    public class ClientConnection
    {
        public static HttpClient _client { get; set; } //in order to open once for each application

        public static void InitializeClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://172.16.3.46/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
