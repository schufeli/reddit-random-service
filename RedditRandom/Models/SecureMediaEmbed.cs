using Newtonsoft.Json;

namespace RedditRandom.Models
{
    public class SecureMediaEmbed
    {
        [JsonProperty("media_domain_url")]
        public string Url { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
