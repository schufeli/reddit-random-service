using Newtonsoft.Json;

namespace RedditRandom.Models
{
    public class GalleryElement
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}