using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditRandom.Models;
using System;
using System.Collections.Generic;

namespace RedditRandom
{
    public class MediaMetadataConverter : JsonConverter<List<GalleryElement>>
    {
        public override List<GalleryElement> ReadJson(JsonReader reader, Type objectType, List<GalleryElement> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }


        public override void WriteJson(JsonWriter writer, List<GalleryElement> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
