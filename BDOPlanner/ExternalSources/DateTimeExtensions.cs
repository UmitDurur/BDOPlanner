using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOPlanner.ExternalSources
{
    public static class DateTimeExtensions
    {
        public static int GetWeekOfYear(this DateTime date)
        {
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static int DayOfWeekEx(this DateTime dt)
        {
            return (dt - dt.StartOfWeek(DayOfWeek.Monday)).Days;
        }
    }
}
