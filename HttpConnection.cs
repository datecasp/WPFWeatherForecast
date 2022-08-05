using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFWeatherForecast
{
    public static class HttpConnection
    {
        /*
         *  This Class only has one static method to manage the HTTP connection to the API
         *  Receives "city" as a parameter to add to the query
         *  uses a constant defined in other class for the API key 
         *  for security reasons
         *  In order to use it you must create this class Constant.cs 
         *  into project root folder and define there a constant public string
         *  with the API key value asigned.
         *  Add this class to the .gitignore file for uploading to github
         */
        public static string HttpConecction(string city) {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
            client.DefaultRequestHeaders.Accept.Clear();
            var query = $"forecast?q={city}&units=metric&appid={Constant.APIKey}";
            var response = client.GetAsync(query).Result;
            var strResponse = response.Content.ReadAsStringAsync().Result;
            return strResponse;
        }
        
    }
}
