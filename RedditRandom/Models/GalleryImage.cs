using Newtonsoft.Json;
using System.Web;

namespace RedditRandom.Models
{
    public class GalleryImage
    {
        [JsonProperty("u")]
        private string _Url;
        public string Url 
        { 
            get { return _Url; }
            set { _Url = HttpUtility.HtmlDecode(value); } // Extended setter -> Url from the API is Decoded
        }
    }
}