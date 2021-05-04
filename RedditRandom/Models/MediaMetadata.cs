using Newtonsoft.Json;
using System.Collections.Generic;

namespace RedditRandom.Models
{
    public class MediaMetadata
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
