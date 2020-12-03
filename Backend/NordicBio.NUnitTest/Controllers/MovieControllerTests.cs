using NUnit.Framework;
using RestSharp;
using System.Net;

namespace NordicBio.NUnitTest
{
    [TestFixture]
    class MovieControllerTests
    {
        // TESTCASES - GET
        [TestCase("movies", HttpStatusCode.OK, TestName = "Get - Check status code is (OK)")]
        public void StatusCodeGetTest(string controller, HttpStatusCode expectedStatusCode)
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest(controller, Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
        }


        // TESTCASES - GET BY ID
        [TestCase("movies", "2", HttpStatusCode.OK, TestName = "Get/{id} - Check status code for correct id is(OK)")]
        [TestCase("movies", "999999", HttpStatusCode.NotFound, TestName = "Get/{id} - Check status code for too high id is (NOTFOUND)")]
        [TestCase("movies", "-10", HttpStatusCode.NotFound, TestName = "Get/{id} - Check status code for negative id is (NOTFOUND)")]
        public void StatusCodeGetByIdTest(string controller, string id, HttpStatusCode expectedHttpStatusCode)
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest($"{controller}/{id}", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedHttpStatusCode));
        }


        [TestCase("movies", "application/json; charset=utf-8", TestName = "Get - Check content type is (application/json)")]

        public void ContentTypeTest(string controller, string contentType)
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest(controller, Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.ContentType, Is.EqualTo(contentType));
        }
    }
}
