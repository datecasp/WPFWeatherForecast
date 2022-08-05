using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
using WPFWeatherForecast.Models;
using static WPFWeatherForecast.Models.FiveDaysModel;

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
                    /*
                     *  FiveDaysModels Root is the class to hold as object the JSON response 
                     *  HttpConnection(city) manages connection to API and returns the answer 
                     *  JSON object into a string for deserialize and create a Root object that
                     *  let us use the values received in the JSON answer
                     */

                    //Deserialize into a Root Object
                    Root weatherForecast = JsonSerializer.Deserialize<Root>(HttpConnection.HttpConecction(city))!;
                    //Add DataContext for Binding the data to the TextBlock´s Text Property
                    DataContext = weatherForecast;
                    //Shows Grid for forecast Layout
                    LayoutGridForecast.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Type a correct city name please.");
                }
            }
        }        
    }
}
