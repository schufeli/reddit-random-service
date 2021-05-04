using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace RedditRandomService
{
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private readonly string _apiKey = Environment.GetEnvironmentVariable("API_KEY");

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided!");
                return;
            }

            if (!_apiKey.Equals(extractedApiKey))

            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid Api Key provided!");
                return;
            }

            await _next(context);
        }
    }
}
