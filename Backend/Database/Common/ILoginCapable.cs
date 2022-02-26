namespace Backend.Database.Common
{
    public interface ILoginCapable
    {
        Account Account { get; set; }
        string AccountUsername { get; set; }
         
    }
}