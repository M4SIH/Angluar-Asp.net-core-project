using Backend.Database.Common;

namespace Backend.Database
{
    public class Manager : Person,ILoginCapable
    {
        public Account Account { get; set; }
        public string AccountUsername { get; set; }
        public string Type { get; set; }
    }
}