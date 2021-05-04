using Newtonsoft.Json;

namespace RedditRandom.Models
{
    public class RedditVideo
    {
        [JsonProperty("fallback_url")]
        public string Url { get; set; }
    }
}
