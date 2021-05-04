using Newtonsoft.Json;

namespace RedditRandom.Models
{
    public class Oembed
    {
        [JsonProperty("thumbnail_width")]
        public int ThumbnailWidth { get; set; }

        [JsonProperty("thumbnail_url")]
        public string Url { get; set; }
    }
}
