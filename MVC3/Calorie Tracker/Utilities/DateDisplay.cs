using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace Calorie_Tracker.Utilities
{
    public class DateDisplay
    {
        private DateTime date;

        public DateDisplay(string dateString)
        {
            date = DateTime.ParseExact(dateString, "ddMMyyyyHHmmss", null);
        }

        public string humanReadableDate()
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        public static string parseDate(string rawDate)
        {
            return DateTime.ParseExact(rawDate, "ddMMyyyyHHmmss", null).ToString("dd/MM/yyyy HH:mm");
        }

        public static string parseDOB(string rawDate)
        {
            DateTime dateTime;
            if (DateTime.TryParseExact(rawDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime)) //If in read format
            {
                return dateTime.ToString("ddMMyyyy");
            }
            else return DateTime.ParseExact(rawDate, "ddMMyyyy", null).ToString("dd/MM/yyyy");
        }
    }
}