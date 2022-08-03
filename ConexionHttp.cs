using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPFWeatherForecast
{
    public static class ConexionHttp
    {
        private static HttpClient Client = new HttpClient();

        public static async void HttpConection(string city)
        {
            
                var result = await Client.GetAsync($"http://api.openweathermap.org/data/2.5/forecast?q=london&appid=635663c9844750b71b316bc7593ac186");
                var response = result.RequestMessage;
            
        }
    }
}
