using PSITS_Web.Common;

namespace PSITS_Web.WebAssembly.Utils
{
    public static class OfficeLogsExtension
    {
        public static OfficeLogs GetLogs(this OfficeLogs officeLogs, DateTime date)
        {
            List<OfficeLog> logList = new List<OfficeLog>();

            foreach(OfficeLog log in officeLogs.officeLogs)
            {
                if (log.loginTime.SameDay(date))
                    logList.Add(log);
            }

            return new OfficeLogs() { officeLogs = logList };
        }

        private static bool SameDay(this DateTime date, DateTime compareDate)
        {
            return date.Day == compareDate.Day && date.Month == compareDate.Month && date.Year == compareDate.Year;
        }
    }
}
