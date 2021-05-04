using Newtonsoft.Json;
using RedditRandom;
using RedditRandom.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace GalleryDeserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new JsonSerializerSettings
            {
                MaxDepth = null
            };

            var jsonString = File.ReadAllText("./Post.json");

            var model = JsonConvert.DeserializeObject<List<Root>>(jsonString, settings);

            Console.WriteLine(model?[0].Data.Children[0].Post.MediaMetadata);

        }
    }
}
