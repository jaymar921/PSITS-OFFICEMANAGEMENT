namespace PSITS_Web.Common
{
    public class User
    {
        public string avatar { get; set; } = string.Empty;
        public int userId { get; set; } = 0;
        public string rfid { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        public DateTime birthdate { get; set; } = DateTime.UtcNow;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public List<Cart> cart { get; set; } = new List<Cart>();
        public string course { get; set; } = string.Empty;
        public int year { get; set; } = 0;
        public bool graduated { get; set; } = false;
        public bool isAdmin { get; set; } = false;
        public bool showPublic { get; set; } = false;
    }
}
