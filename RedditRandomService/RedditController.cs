using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedditRandom;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using RedditRandom.Models;
using Newtonsoft.Json;

namespace RedditRandomService
{
    [ApiController]
    [Route("[controller]")]
    public class RedditController : ControllerBase
    {
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly string _userAgent = Environment.GetEnvironmentVariable("USER_AGENT");

        #region Constructor
        public RedditController()
        {
            _jsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };
        }
        #endregion

        [HttpGet("{subreddit}")]
        public async Task<ActionResult<Response>> GetAsync(string subreddit)
        {
            HttpContext.Request.Headers.TryGetValue("AccessToken", out var accessToken);

            if (string.IsNullOrEmpty(accessToken.ToString()))
                return new UnauthorizedResult();

            WebAgent agent = new WebAgent(accessToken, _userAgent);
            var request = agent.CreateRequest(subreddit);
            var response = await agent.GetResponseAsync(request);

            if (!response.IsSuccessStatusCode)
                return new StatusCodeResult((int)response.StatusCode);

            var jsonString = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<List<Root>>(jsonString);


            return new JsonResult(
                ResponseFactory.CreateResponseFromPost(content?[0].Data.Children[0].Post),
                _jsonSettings
            );
        }
    }
}
