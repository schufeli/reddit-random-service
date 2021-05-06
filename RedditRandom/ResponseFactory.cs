using RedditRandom.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace RedditRandom
{
    public static class ResponseFactory
    {
        private static (PostType, string, List<string>) ParsePost(Post post)
        {
            _ = post ?? throw new ArgumentNullException(nameof(post));

            /* Post is Video*/
            if (post.IsVideo)
                return new(PostType.Video, post.SecureMedia.RedditVideo.Url, null);

            /* Post is Text */
            if (post.Title.Length > 0 && post.Selftext.Length > 0 && post.SelftextHtml != null)
                return new(PostType.Text, null, null);

            /* Post is Embed */
            if (post.SecureMedia != null && !post.IsVideo)
                return new(PostType.Embed, HttpUtility.HtmlDecode(post.SecureMediaEmbed.Content), null); // First unescape JSON then HTML

            /* Post is Gallery*/
            if (post.Url.Contains("gallery"))
            {
                var gallery = new List<string>();

                foreach (var element in post.Gallery)
                {
                    gallery.Add(HttpUtility.HtmlDecode(element.Image.Url));
                }

                return new(PostType.Gallery, null, gallery);
            }

            /* Post is Image */
            if (post.Preview?.Images.Count >= 0)
                return new(PostType.Image, HttpUtility.HtmlDecode(post.Preview.Images[0].Source.Url), null);

            throw new NotImplementedException();
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
