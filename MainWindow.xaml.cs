using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFWeatherForecast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string city;
        private static HttpClient Client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();

        }

        /*
         *  LayoutIntro button onCLick event
         *      -Hide LayoutIntro
         *      -Visible LayoutForecast
         */
        private void BtnIntro_Click(object sender, RoutedEventArgs e)
        {
            LayoutIntro.Visibility = Visibility.Hidden;
            LayoutForecast.Visibility = Visibility.Visible;
        }

        /*
         *  LayoutForecast button btnCity onClick event
         *      -Check if boxCity has any value
         *          -if false -> Show Message to fill the box with a city
         *          -if true -> Try to connect API with the text typed in the box
         * 
         */
        private void BtnCity_Click(object sender, RoutedEventArgs e)
        {
            city = boxCity.Text;
            if (city == "")
            {
                MessageBox.Show("Type in a city to get the forecast");
            }
            else
            {
                try
                {
                    //Define method to connect to the API with async try-catch
                    //URL http://api.openweathermap.org/data/2.5/forecast?q=london&appid= API ID HERE
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    var query = $"forecast?q={city}&appid=API ID HERE";
                    var response = client.GetAsync(query).Result;
                    var strResponse = response.Content.ReadAsStringAsync().Result;
                    
                    txtResponse.Text = strResponse;
                    LayoutIntro.Visibility = Visibility.Hidden;
                    GridForecast.Visibility = Visibility.Visible;
                }
                catch(Exception ex)
                {
                    txtResponse.Text = ex.Message;
                }
            }
        }


        
    }
}
