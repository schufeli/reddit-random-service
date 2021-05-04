using Newtonsoft.Json;

namespace RedditRandom.Models
{
    public class SecureMedia
    {
        [JsonProperty("reddit_video")]
        public RedditVideo RedditVideo { get; set; }

        [JsonProperty("oembed")]
        public Oembed Oembed { get; set; }
    }
}
