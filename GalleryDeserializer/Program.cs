using Newtonsoft.Json;
using RedditRandom;
using RedditRandom.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace GalleryDeserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = File.ReadAllText("./post_embed_youtube.json");

            var model = JsonConvert.DeserializeObject<List<Root>>(jsonString);

            var post = ResponseFactory.CreateResponseFromPost(model?[0].Data.Children[0].Post);

            Console.WriteLine(post.MediaSource);
        }
    }
}
