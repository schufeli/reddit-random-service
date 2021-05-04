using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditRandom.Models;
using System;
using System.Collections.Generic;

namespace RedditRandom
{
    public class MediaMetadataConverter : JsonConverter<MediaMetadata>
    {
        public override MediaMetadata ReadJson(JsonReader reader, Type objectType, MediaMetadata existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, MediaMetadata value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
