using RedditRandom.Models;
using System;
using System.Collections.Generic;

namespace RedditRandom
{
    public class ResponseBuilder
    {
        private Response _response = new();

        private ResponseBuilder Set(Action<Response> action)
        {
            action(_response);
            return this;
        }

        public ResponseBuilder SetSubreddit(string subreddit) //ToDo maybe do some validation?
            => Set(response => response.Subreddit = subreddit);

        public ResponseBuilder SetUsername(string username) //ToDo maybe do some validation?
            => Set(response => response.UserName = username);

        public ResponseBuilder SetSpoiler(bool spoiler) //ToDo maybe do some validation?
            => Set(response => response.Spoiler = spoiler);

        public ResponseBuilder SetTitle(string title) //ToDo maybe do some validation?
            => Set(response => response.Title = title);

        public ResponseBuilder SetSelfText(string selfText) //ToDo maybe do some validation?
            => Set(response => response.SelfText = selfText);

        public ResponseBuilder SetPermalink(string permalink) //ToDo maybe do some validation?
            => Set(response => response.Permalink = permalink);

        public ResponseBuilder SetPostLink(string postLink) //ToDo maybe do some validation?
            => Set(response => response.PostLink = postLink);

        public ResponseBuilder SetMediaSource(string mediaSource) //ToDo maybe do some validation?
            => Set(response => response.MediaSource = mediaSource);

        public ResponseBuilder SetGallery(List<string> gallery) //ToDo maybe do some validation?
            => Set(response => response.Gallery = gallery);

        public ResponseBuilder SetPostType(PostType postType)
            => Set(response => response.PostType = postType);

        public Response Build()
        {
            //ToDo maybe validate all fields?

            var response = _response;
            _response = new();
            return response;
        }

        public static implicit operator Response(ResponseBuilder builder)
            => (_ = builder ?? throw new ArgumentNullException(nameof(builder))).Build();
    }
}
