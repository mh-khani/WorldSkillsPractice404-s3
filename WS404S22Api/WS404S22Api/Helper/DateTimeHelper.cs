using System.Globalization;
using System.Runtime.CompilerServices;

namespace WS404S22Api.Helper
{
    public static class DateTimeHelper
    {
        private static PersianCalendar calendar = new();
        public static string ToShamsiDate(DateTime date)
        {
            return calendar.GetYear(date) + "/" + calendar.GetMonth(date).ToString("00") + "/" + calendar.GetDayOfMonth(date).ToString("00");
        }
    }
}
