using Newtonsoft.Json;
using System.Collections.Generic;

namespace RedditRandom.Models
{
    public class Post
    {

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("selftext")]
        public string Selftext { get; set; }

        [JsonProperty("selftext_html")]
        public string SelftextHtml { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("name")]
        public string UserName { get; set; }

        [JsonProperty("is_reddit_media_domain")]
        public bool IsRedditMediaDomain { get; set; }

        [JsonProperty("is_meta")]
        public bool IsMeta { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("spoiler")]
        public bool Spoiler { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

        [JsonProperty("crosspost_parent_list")]
        public List<Post> CrossPosts { get; set; }

        [JsonProperty("media_metadata")]
        [JsonConverter(typeof(GalleryElementConverter))]
        public List<GalleryElement> Gallery { get; set; }

        [JsonProperty("secure_media")]
        public SecureMedia SecureMedia { get; set; }

        [JsonProperty("secure_media_embed")]
        public SecureMediaEmbed SecureMediaEmbed { get; set; }

        [JsonProperty("preview")]
        public Preview Preview { get; set; }
    }
}
