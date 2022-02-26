

namespace Backend.Database
{
    public class Account
    {
        public string Username { get; set; }
        // [StringLength(35, MinimumLength = 8)]
        public string Password { get; set; }
        public User User { get; set; }
        public Writer Writer { get; set; }
        public Manager Manager { get; set; }
    }
}