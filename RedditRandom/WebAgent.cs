using RedditRandom.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RedditRandom
{
    public class WebAgent : IWebAgent
    {
        private HttpClient HttpClient { get; set; }

        /// <inheritdoc/>
        public string AccessToken { get; }

        /// <inheritdoc/>
        public string UserAgent { get; }

        public WebAgent(string accssToken, string userAgent)
        {
            AccessToken = accssToken;
            UserAgent = userAgent;
            HttpClient = new HttpClient();
        }

        /// <inheritdoc/>
        public HttpRequestMessage CreateRequest(string subreddit)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://oauth.reddit.com/r/{subreddit}/random");

            request.Headers.Authorization = new AuthenticationHeaderValue("bearer", AccessToken);
            request.Headers.TryAddWithoutValidation("User-Agent", AccessToken);

            return request;
        }

        /// <inheritdoc/>
        public Task<HttpResponseMessage> GetResponseAsync(HttpRequestMessage message)
        {
            return HttpClient.SendAsync(message);
        }
    }
}
