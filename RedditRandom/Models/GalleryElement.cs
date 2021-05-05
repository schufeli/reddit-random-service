using Newtonsoft.Json;
using System.Collections.Generic;

namespace RedditRandom.Models
{
    public class GalleryElement
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("s")]
        public GalleryImage Image { get; set; }
    }
}
