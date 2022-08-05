using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFWeatherForecast.Models
{
    public  class FiveDaysGrid
    {
        public  Grid FiveDaysFillGrid (string city)
        {
            FiveDaysModel.Root wf = JsonSerializer.Deserialize<FiveDaysModel.Root>(HttpConnection.HttpConecction(city))!;

            // Create the Grid
            Grid myGrid = new Grid();
            myGrid.Width = 650;
            myGrid.Height = 300;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;

            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();
            ColumnDefinition colDef4 = new ColumnDefinition();
            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);
            myGrid.ColumnDefinitions.Add(colDef4);

            // Define the Rows
            RowDefinition rowDef0 = new RowDefinition();
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef0);
            myGrid.RowDefinitions.Add(rowDef1);
            myGrid.RowDefinitions.Add(rowDef2);
            myGrid.RowDefinitions.Add(rowDef3);
            myGrid.RowDefinitions.Add(rowDef4);

            // Add the Day text cell to the Grid
            TextBlock txtTittle = new TextBlock();
            txtTittle.Text = $"Weather forecast for {city}";
            txtTittle.FontSize = 20;
            txtTittle.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtTittle, 0);
            Grid.SetColumnSpan(txtTittle, 4);

            // Add the Day text cell to the Grid
            TextBlock txtCell00 = new TextBlock();
            txtCell00.Text = "Day";
            txtCell00.FontSize = 20;
            txtCell00.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtCell00, 1);
            Grid.SetColumn(txtCell00, 0);

            // Add the TEMP text cell to the Grid
            TextBlock txtCell01 = new TextBlock();
            txtCell01.Text = "Temperature";
            txtCell01.FontSize = 20;
            txtCell01.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtCell01, 1);
            Grid.SetColumn(txtCell01, 1);

            // Add the PRECIP text cell to the Grid
            TextBlock txtCell02 = new TextBlock();
            txtCell02.Text = "Wind";
            txtCell02.FontSize = 20;
            txtCell02.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtCell02, 1);
            Grid.SetColumn(txtCell02, 2);

            // Add the SKY text cell to the Grid
            TextBlock txtCell03 = new TextBlock();
            txtCell03.Text = "Sky";
            txtCell03.FontSize = 20;
            txtCell03.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtCell03, 1);
            Grid.SetColumn(txtCell03, 3);
            
            // Add the DAY1 text cell to the Grid
            TextBlock txtDay1 = new TextBlock();
            txtDay1.Text = wf.list[0].dt_txt.ToString();
            txtDay1.FontSize = 12;
            txtDay1.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay1, 2);
            Grid.SetColumn(txtDay1, 0);

            // Add the DAY1TEMP text cell to the Grid
            TextBlock txtDay1Temp = new TextBlock();
            txtDay1Temp.Text = wf.list[0].main.temp.ToString()+" ºC";
            txtDay1Temp.FontSize = 12;
            txtDay1Temp.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay1Temp, 2);
            Grid.SetColumn(txtDay1Temp, 1);

            // Add the DAY1WIND text cell to the Grid
            TextBlock txtDay1Wind = new TextBlock();
            txtDay1Wind.Text = wf.list[0].wind.speed.ToString() + " m/s";
            txtDay1Wind.FontSize = 12;
            txtDay1Wind.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay1Wind, 2);
            Grid.SetColumn(txtDay1Wind, 2);

            // Add the DAY1SKY text cell to the Grid
            TextBlock txtDay1Sky = new TextBlock();
            txtDay1Sky.Text = wf.list[0].weather[0].main.ToString();
            txtDay1Sky.FontSize = 12;
            txtDay1Sky.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay1Sky, 2);
            Grid.SetColumn(txtDay1Sky, 3);
            
            // Add the DAY2 text cell to the Grid
            TextBlock txtDay2 = new TextBlock();
            txtDay2.Text = wf.list[8].dt_txt.ToString();
            txtDay2.FontSize = 12;
            txtDay2.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay2, 3);
            Grid.SetColumn(txtDay2, 0);

            // Add the DAY2TEMP text cell to the Grid
            TextBlock txtDay2Temp = new TextBlock();
            txtDay2Temp.Text = wf.list[8].main.temp.ToString() + " ºC";
            txtDay2Temp.FontSize = 12;
            txtDay2Temp.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay2Temp, 3);
            Grid.SetColumn(txtDay2Temp, 1);

            // Add the DAY2WIND text cell to the Grid
            TextBlock txtDay2Wind = new TextBlock();
            txtDay2Wind.Text = wf.list[8].wind.speed.ToString()+" m/s";
            txtDay2Wind.FontSize = 12;
            txtDay2Wind.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay2Wind, 3);
            Grid.SetColumn(txtDay2Wind, 2);

            // Add the DAY2SKY text cell to the Grid
            TextBlock txtDay2Sky = new TextBlock();
            txtDay2Sky.Text = wf.list[8].weather[0].main.ToString();
            txtDay2Sky.FontSize = 12;
            txtDay2Sky.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay2Sky, 3);
            Grid.SetColumn(txtDay2Sky, 3);
            
            // Add the DAY3 text cell to the Grid
            TextBlock txtDay3 = new TextBlock();
            txtDay3.Text = wf.list[16].dt_txt.ToString();
            txtDay3.FontSize = 12;
            txtDay3.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay3, 4);
            Grid.SetColumn(txtDay3, 0);

            // Add the DAY3TEMP text cell to the Grid
            TextBlock txtDay3Temp = new TextBlock();
            txtDay3Temp.Text = wf.list[16].main.temp.ToString() + " ºC";
            txtDay3Temp.FontSize = 12;
            txtDay3Temp.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay3Temp, 4);
            Grid.SetColumn(txtDay3Temp, 1);

            // Add the DAY3WIND text cell to the Grid
            TextBlock txtDay3Wind = new TextBlock();
            txtDay3Wind.Text = wf.list[16].wind.speed.ToString() + " m/s";
            txtDay3Wind.FontSize = 12;
            txtDay3Wind.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay3Wind, 4);
            Grid.SetColumn(txtDay3Wind, 2);

            // Add the DAY3SKY text cell to the Grid
            TextBlock txtDay3Sky = new TextBlock();
            txtDay3Sky.Text = wf.list[16].weather[0].main.ToString();
            txtDay3Sky.FontSize = 12;
            txtDay3Sky.FontWeight = FontWeights.Bold;
            Grid.SetRow(txtDay3Sky, 4);
            Grid.SetColumn(txtDay3Sky, 3);

            // Add the TextBlock elements to the Grid Children collection
            myGrid.Children.Add(txtTittle);
            myGrid.Children.Add(txtCell00);
            myGrid.Children.Add(txtCell01);
            myGrid.Children.Add(txtCell02);
            myGrid.Children.Add(txtCell03);
            myGrid.Children.Add(txtDay1);
            myGrid.Children.Add(txtDay1Temp);
            myGrid.Children.Add(txtDay1Wind);
            myGrid.Children.Add(txtDay1Sky);
            myGrid.Children.Add(txtDay2);
            myGrid.Children.Add(txtDay2Temp);
            myGrid.Children.Add(txtDay2Wind);
            myGrid.Children.Add(txtDay2Sky);
            myGrid.Children.Add(txtDay3);
            myGrid.Children.Add(txtDay3Temp);
            myGrid.Children.Add(txtDay3Wind);
            myGrid.Children.Add(txtDay3Sky);


            return myGrid;
        }
    }
}
