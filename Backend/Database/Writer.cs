using Backend.Database.Common;

namespace Backend.Database
{
    public class Writer : Person,ILoginCapable
    {
        public Account Account { get; set; }
        public string AccountUsername { get; set; }
        public string Level { get; set; } 
    }
}