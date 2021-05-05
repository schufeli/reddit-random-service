using Newtonsoft.Json;

namespace RedditRandom.Models
{
    public class GalleryImage
    {
        [JsonProperty("u")]
        public string Url { get; set; }
    }
}