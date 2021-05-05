using Newtonsoft.Json;
using System.Collections.Generic;

namespace RedditRandom.Models
{
    [JsonObject]
    public class Gallery
    {
        [JsonProperty("media_metadata")]
        [JsonConverter(typeof(GalleryElementConverter))]
        public List<GalleryElement> GalleryElements { get; set; }
    }
}
