using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedditRandom;

namespace RedditRandomTest
{
    [TestClass]
    public class WebAgentTests
    {
        [TestMethod]
        public void CreateWebAgent_CreateNewWebAgent_CreateValidAgent() 
        {
            // Arrange
            string accessToken = "1234";
            string userAgent = "ReddditRandomService:v1.0";

            // Act
            var agent = new WebAgent(accessToken, userAgent);

            // Assert
            Assert.AreEqual(userAgent, agent.UserAgent);
        }

        [TestMethod]
        public void CreateWebAgent_CreateRequest_CreateValidRequest()
        {
            // Arrange
            string accessToken = "1234";
            string userAgent = "ReddditRandomService:v1.0";

            // Act
            var agent = new WebAgent(accessToken, userAgent);
            var request = agent.CreateRequest("csharp");

            // Assert
            Assert.AreEqual(1, request.Headers.UserAgent.Count);
        }

        [TestMethod]
        public void CreateWebAgent_GetResponseAsny_ReturnValidResponse()
        {
            // Arrange
            string accessToken = "1234";
            var userAgent = "ReddditRandomService:v1.0";

            // Act
            var agent = new WebAgent(accessToken, userAgent);

            // Assert
        }
    }
}
