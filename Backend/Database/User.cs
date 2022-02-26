using Backend.Database.Common;

namespace Backend.Database
{
    public class User : Person,ILoginCapable
    {
        public Account Account { get; set; }
        public string AccountUsername { get; set; }
    }
}