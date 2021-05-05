

using System.Collections.Generic;

namespace RedditRandom.Models
{
    public class Response
    {
        public string Subreddit { get; set; }
        public string UserName { get; set; }
        public bool Spoiler { get; set; }
        public string Title { get; set; }
        public string SelfText { get; set; }
        public string Permalink { get; set; }
        public string PostLink { get; set; }
        public string MediaSource { get; set; }
        public List<string> Gallery { get; set; }
        public PostType PostType { get; set; }
    }

    public enum PostType
    {
        Image,
        Video,
        Embed,
        Text,
        Gallery
    }
}
