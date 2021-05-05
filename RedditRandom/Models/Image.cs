using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;

namespace RedditRandom.Models
{
    public class Image
    {
        [JsonProperty("source")]
        public Source Source { get; set; }
    }

    public class Preview
    {
        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }

    public class Source
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
