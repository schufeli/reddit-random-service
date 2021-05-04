using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedditRandom;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Collections.Generic;
using RedditRandom.Models;

namespace RedditRandomService
{
    [ApiController]
    [Route("[controller]")]
    public class RedditController : ControllerBase
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly string _userAgent = Environment.GetEnvironmentVariable("USER_AGENT");

        #region Constructor
        public RedditController()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                IgnoreNullValues = true
            };
        }
        #endregion

        [HttpGet("{subreddit}")]
        public async Task<IActionResult> GetAsync(string subreddit)
        {
            HttpContext.Request.Headers.TryGetValue("AccessToken", out var accessToken);

            if (string.IsNullOrEmpty(accessToken.ToString()))
                return new UnauthorizedResult();

            WebAgent agent = new WebAgent(accessToken, _userAgent);
            var request = agent.CreateRequest(subreddit);
            var response = await agent.GetResponseAsync(request);

            if (!response.IsSuccessStatusCode)
                return new StatusCodeResult((int)response.StatusCode);

            var content = await response.Content.ReadFromJsonAsync<List<Root>>();

            return new JsonResult(
                // ResponseFactory.CreateResponseFromPost(content?[0].Data.Children[0].Post),
                content?[0].Data.Children[0].Post,
                _jsonSerializerOptions
            );
        }
    }
}
