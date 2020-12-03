using NUnit.Framework;
using RestSharp;
using System.Net;

namespace NordicBio.NUnitTest
{
    [TestFixture]
    class DataDrivenTests
    {
        [TestCase("movies", "2", HttpStatusCode.OK, TestName = "Check status code for correct id")]
        [TestCase("movies", "999999", HttpStatusCode.NotFound, TestName = "Check status code for too high id")]
        [TestCase("movies", "-10", HttpStatusCode.NotFound, TestName = "Check status code for negative id")]
        public void StatusCodeTest(string controller, string id, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest($"{controller}/{id}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }
    }
}
