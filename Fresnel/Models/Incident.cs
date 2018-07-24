using Newtonsoft.Json;

namespace Fresnel.Models
{
    public class Incident
    {
        //[JsonProperty("id")]
        public int Count { get; set; }
        public string Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
