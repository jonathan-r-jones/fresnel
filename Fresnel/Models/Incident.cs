using Newtonsoft.Json;

namespace Fresnel.Models
{
    public class Incident
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
