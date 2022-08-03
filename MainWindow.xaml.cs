using System;
using System.Collections.Generic;
using System.Linq;
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
                //Define method to connect to the API with async try-catch
            }
        }
    }
}
