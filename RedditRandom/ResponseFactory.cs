using System;
using System.Collections.Generic;
using System.Web;
using RedditRandom.Models;

namespace RedditRandom
{
    public static class ResponseFactory
    {
        private static (PostType, string, List<string>) ParsePost(Post post)
        {
            _ = post ?? throw new ArgumentNullException(nameof(post));

            if (post.IsVideo)
                return new(PostType.Video, post.SecureMedia.RedditVideo.Url, null);

            if (post.Title.Length > 0 && post.Selftext.Length > 0)
                return new(PostType.Text, null, null);

            if (post.SecureMedia != null && !post.IsVideo)
                return new(PostType.Embed, post.SecureMedia.Oembed.Url, null);

            if (post.Url.Contains("gallery"))
            {
                var gallery = new List<string>();

                foreach (var element in post.Gallery[0].GalleryElements)
                {
                    gallery.Add(HttpUtility.HtmlDecode(element.Image.Url));
                }

                return new(PostType.Gallery, null, gallery);
            }
                
            return new(PostType.Image, HttpUtility.HtmlDecode(post.Preview.Images[0].Source.Url), null);
        }

        public static Response CreateResponseFromPost(Post post)
        {
            var (postType, mediaSource, gallery) = ParsePost(post); //ToDo find a better name for it

            var builder = new ResponseBuilder()
                .SetSubreddit(post.Subreddit)
                .SetUsername(post.UserName)
                .SetSpoiler(post.Spoiler)
                .SetTitle(post.Title)
                .SetSelfText(post.Selftext)
                .SetPermalink(post.Permalink)
                .SetPostLink(post.Url)
                .SetMediaSource(mediaSource)
                .SetGallery(gallery)
                .SetPostType(postType);

            return builder;
        }
    }
}
