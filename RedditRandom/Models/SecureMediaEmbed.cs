using Newtonsoft.Json;

namespace RedditRandom.Models
{
    public class SecureMediaEmbed
    {
        [JsonProperty("media_domain_url")]
        public string Url { get; set; }
    }
}
