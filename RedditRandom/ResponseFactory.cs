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
                return new(PostType.Embed, post.SecureMediaEmbed.Url, null);

            if (post.Url.Contains("gallery"))
            {
                var gallery = new List<string>();

                foreach (var element in post.Gallery)
                {
                    gallery.Add(HttpUtility.HtmlDecode(element.Image.Url));
                }

                return new(PostType.Gallery, null, gallery);
            }
                
            return new(PostType.Image, HttpUtility.HtmlDecode(post.Preview.Images[0].Source.Url), null);
        }

        public static Response CreateResponseFromPost(Post post)
        {
            PostType postType; 
            string mediaSource; 
            List<string> gallery;

            if (post.CrossPosts != null)
                (postType, mediaSource, gallery) = ParsePost(post.CrossPosts[0]);
            else
                (postType, mediaSource, gallery) = ParsePost(post);

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
