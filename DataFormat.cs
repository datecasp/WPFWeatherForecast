using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFWeatherForecast
{
    public static class DataFormat
    {
        /*
         * These four methods are used to find the day of the week 
         * and cast it into its string name
         */

        public static List<string> DayOfWeek(string dt_txt)
        {
            int day = FindDay(dt_txt);
            int month = FindMonth(dt_txt);
            int year = FindYear(dt_txt);
            DateTime dt = new DateTime(year, month, day);
            string strMonth = ConvertMonth(dt.Month);
            List<string> returnList = new List<string>{dt.DayOfWeek.ToString(), dt.Day.ToString(), strMonth, year.ToString()};
            return returnList;  
        }

        private static int FindDay(string dt_txt)
        {
            string strDay = dt_txt.Substring(8, 2);
            return int.Parse(strDay);
        }

        private static int FindMonth(string dt_txt)
        {
            string strMonth = dt_txt.Substring(5, 2);
            return int.Parse(strMonth);
        }

        private static int FindYear(string dt_txt)
        {
            string strYear = dt_txt.Substring(0, 4);
            return int.Parse(strYear);
        }

        private static string ConvertMonth(int dtMonth)
        {
            List<string> months = new List<string> { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            return months[dtMonth - 1];
        }
    }
}
