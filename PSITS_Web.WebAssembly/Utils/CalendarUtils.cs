namespace PSITS_Web.WebAssembly.Utils
{
    public class CalendarUtils
    {
        public static string GetDay(int day)
        {
            switch (day)
            {
                case 1: return "Mon";
                case 2: return "Tue";
                case 3: return "Wed";
                case 4: return "Thu";
                case 5: return "Fri";
                case 6: return "Sat";
                case 7: return "Sun";
                default:
                    break;
            }
            return "Inv";
        }

        public static int GetNumberOfDaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public static int GetDayOfWeek(DateTime date)
        {
            return GetDayOfWeek(1, date.Month, date.Year);
        }

        public static int GetDayOfWeek(int day, int month, int year)
        {
            return ((int)new DateTime(year,month, day).DayOfWeek) + 1;
        }
    }
}
