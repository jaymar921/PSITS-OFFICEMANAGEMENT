namespace PSITS_Web.Common
{
    public class OfficeLog
    {
        public User user { get; set; } = new();
        public DateTime loginTime { get; set; } = DateTime.Now;
        public DateTime? logoutTime { get; set; } = null;
        public string remarks { get; set; } = string.Empty;  
    }
}
