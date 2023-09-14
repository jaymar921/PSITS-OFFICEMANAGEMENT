using System.Text;

namespace PSITS_Web.Common
{
    public class OfficeLogs
    {
        public IEnumerable<OfficeLog> officeLogs { get; set; } = new List<OfficeLog>();

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (OfficeLog log in officeLogs)
                builder.Append(log.ToString()).Append("\n");
            return builder.ToString();
        }
    }
}
