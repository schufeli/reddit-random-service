using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedditRandom.Models
{
    public class CrosspostParentList
    {
        [JsonProperty("media_metadata")]
        [JsonConverter(typeof(MediaMetadataConverter))]
        public MediaMetadata MediaMetadata { get; set; }
    }
}
