using System.Net.Http;
using System.Threading.Tasks;

namespace RedditRandom.Interfaces
{
    public interface IWebAgent
    {
        /// <summary>
        /// Reddit API Token to call Reddit Endpoints
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// Unique application identifier to call Reddit Endpoints to mitigate possible API ban
        /// See https://github.com/reddit-archive/reddit/wiki/API for further information.
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// Method to create the API Request
        /// </summary>
        /// <param name="subreddit">Desired subreddit to fetch from</param>
        /// <returns></returns>
        HttpRequestMessage CreateRequest(string subreddit);

        /// <summary>
        /// Executes the API request against the Reddit Endpoint
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> GetResponseAsync(HttpRequestMessage message);
    }
}
