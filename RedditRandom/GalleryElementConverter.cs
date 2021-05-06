using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditRandom.Models;
using System;
using System.Collections.Generic;

namespace RedditRandom
{
    public class GalleryElementConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            => objectType == typeof(List<GalleryElement>);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var response = new List<GalleryElement>();

            JObject elements = JObject.Load(reader);

            foreach (var element in elements)
            {
                var e = JsonConvert.DeserializeObject<GalleryElement>(element.Value.ToString());
                response.Add(e);
            }

            return response;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    //public class MediaMetadataConverter : JsonConverter<List<GalleryElement>>
    //{
    //    public override List<GalleryElement> ReadJson(JsonReader reader, Type objectType, List<GalleryElement> existingValue, bool hasExistingValue, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public override void WriteJson(JsonWriter writer, List<GalleryElement> value, JsonSerializer serializer)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
