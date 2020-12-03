using NUnit.Framework;
using RestSharp;
using System.Net;

namespace NordicBio.NUnitTest
{
    class SeatControllerTests
    {
        [TestCase("seat", HttpStatusCode.OK, TestName = "Get - Check status code is (OK)")]

        public void StatusCodeTest(string controller, HttpStatusCode expectedStatusCode)
        {
            // arrange
            RestClient client = new RestClient("http://localhost:5000/api");
            RestRequest request = new RestRequest(controller, Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode));
        }





        [TestCase("seat", "application/json; charset=utf-8", TestName = "Get - Check content type is (application/json)")]

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
