using Newtonsoft.Json.Linq;

namespace Backend.Models
{
    public class ListRequest
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public JObject Filter { get; set; }
    }
}