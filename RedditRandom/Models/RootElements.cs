using Newtonsoft.Json;
using System.Collections.Generic;

namespace RedditRandom.Models
{
    public class Root
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("children")]
        public List<Child> Children { get; set; }
    }

    public class Child
    {
        [JsonProperty("data")]
        public Post Post { get; set; }
    }
}
