using Newtonsoft.Json;
using System.Web;

namespace RedditRandom.Models
{
    public class GalleryImage
    {
        [JsonProperty("u")]
        public string Url { get; set; }
    }
}