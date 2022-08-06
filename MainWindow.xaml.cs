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

                    //Assign icons to image cell grid
                    imgSky10.Source = IconSelector(weatherForecast.list[0].weather[0].main, weatherForecast.list[0].weather[0].description);
                    imgSky20.Source = IconSelector(weatherForecast.list[8].weather[0].main, weatherForecast.list[8].weather[0].description);
                    imgSky30.Source = IconSelector(weatherForecast.list[16].weather[0].main, weatherForecast.list[16].weather[0].description);

                    //Shows Grid for forecast Layout
                    LayoutGridForecast.Visibility = Visibility.Visible;

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Type a correct city name please.");
                }
            }
        }        

        /*
         * IconSelector checks weather[0].main value and selects 
         * the correct icon to display.
         * For some weather[0].main definitions there are several
         * icons avaliable based in weather[0].description
         * These options are based in openweathermap.org icons
         */
        private BitmapImage IconSelector(string weatherMain, string weatherDescription)
        {
            BitmapImage icon = null;
            switch (weatherMain)
            {
                case "Clouds":
                    if ((weatherDescription.Equals("few clouds")) || (weatherDescription.Equals("scattered clouds")))
                    {
                        icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/cloudy.png"));
                    }
                    else
                    {
                        icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/overcast.png"));
                    }
                    return icon;
                case "Snow":
                    icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/snow.png"));
                    return icon;
                case "Clear":
                    icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/sunny.png"));
                    return icon;
                case "Drizzle":
                    icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/lightrain.png"));
                    return icon;
                case "Thunderstorm":
                    icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/thunderstorm.png"));
                    return icon;
                case "Rain":
                    if (weatherDescription.Equals("light rain"))
                    {
                        icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/lightrain.png"));
                    }
                    else
                    {
                        icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/rain.png"));
                    }
                    return icon;
                default:
                    icon = new BitmapImage(new Uri("C:/Users/Danny/Desktop/Programación/WPFWeatherForecast/Assets/atmosphere.png"));
                    return icon;
            }
        }
    }
}
